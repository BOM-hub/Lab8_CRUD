using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab8_CRUD
{
    public partial class Form1 : Form
    {
        private readonly string _connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=StudentDB;Integrated Security=True;";

        private DataTable _studentsTable = new DataTable();
        private int _selectedId = -1;
        private bool _isLoading = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            LoadStudents("Готово");
        }

        public void LoadStudents(string statusPrefix = "Готово")
        {
            _isLoading = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string sql = "SELECT Id, FullName, Age, GroupName, AverageGrade FROM Students ORDER BY Id";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    _studentsTable = new DataTable();
                    adapter.Fill(_studentsTable);

                    dataGridViewStudents.DataSource = _studentsTable.DefaultView;
                    ConfigureColumns();

                    labelStatus.Text = $"{statusPrefix} | Всего студентов: {_studentsTable.Rows.Count}";
                }
            }
            catch (SqlException ex)
            {
                labelStatus.Text = "Ошибка загрузки данных";
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message,
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }

            if (dataGridViewStudents.Rows.Count > 0)
            {
                dataGridViewStudents.Rows[0].Selected = true;
                FillFieldsFromSelectedRow();
            }
            else
            {
                ClearFields();
            }
        }

        private void ConfigureColumns()
        {
            if (dataGridViewStudents.Columns.Count == 0)
                return;

            var colId = dataGridViewStudents.Columns["Id"];
            var colName = dataGridViewStudents.Columns["FullName"];
            var colAge = dataGridViewStudents.Columns["Age"];
            var colGroup = dataGridViewStudents.Columns["GroupName"];
            var colGrade = dataGridViewStudents.Columns["AverageGrade"];

            if (colId != null) { colId.HeaderText = "Код"; colId.FillWeight = 10; }
            if (colName != null) { colName.HeaderText = "ФИО"; colName.FillWeight = 40; }
            if (colAge != null) { colAge.HeaderText = "Возраст"; colAge.FillWeight = 14; }
            if (colGroup != null) { colGroup.HeaderText = "Группа"; colGroup.FillWeight = 16; }
            if (colGrade != null)
            {
                colGrade.HeaderText = "Средний балл";
                colGrade.FillWeight = 20;
                colGrade.DefaultCellStyle.Format = "0.00";
            }
        }

        private void dataGridViewStudents_SelectionChanged(object? sender, EventArgs e)
        {
            if (_isLoading)
                return;

            FillFieldsFromSelectedRow();
        }

        private void FillFieldsFromSelectedRow()
        {
            if (dataGridViewStudents.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dataGridViewStudents.SelectedRows[0];
            if (row.Cells["Id"].Value == null || row.Cells["Id"].Value == DBNull.Value)
                return;

            _selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            textBoxName.Text = row.Cells["FullName"].Value?.ToString() ?? string.Empty;
            numericAge.Value = Convert.ToDecimal(row.Cells["Age"].Value);
            textBoxGroup.Text = row.Cells["GroupName"].Value?.ToString() ?? string.Empty;
            numericGrade.Value = Convert.ToDecimal(row.Cells["AverageGrade"].Value);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите ФИО студента!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxGroup.Text))
            {
                MessageBox.Show("Введите учебную группу!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxGroup.Focus();
                return false;
            }

            return true;
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            AddStudentInternal(silentCapture: false);
        }

        public bool AddStudentInternal(bool silentCapture = false)
        {
            if (!ValidateInputs())
                return false;

            string fullName = textBoxName.Text.Trim();
            int age = (int)numericAge.Value;
            string group = textBoxGroup.Text.Trim();
            double grade = (double)numericGrade.Value;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string checkSql = "SELECT COUNT(*) FROM Students WHERE FullName = @name";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@name", fullName);
                        int existing = (int)checkCmd.ExecuteScalar();
                        if (existing > 0)
                        {
                            labelStatus.Text = $"Дубликат: студент «{fullName}» уже есть в БД";
                            if (!silentCapture)
                            {
                                MessageBox.Show($"Студент «{fullName}» уже существует в базе данных!",
                                    "Проверка дубликата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            return false;
                        }
                    }

                    string insertSql = @"INSERT INTO Students (FullName, Age, GroupName, AverageGrade)
                                         VALUES (@name, @age, @group, @grade)";
                    using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", fullName);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@group", group);
                        cmd.Parameters.AddWithValue("@grade", grade);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadStudents($"Добавлен студент: {fullName}");
                SelectRowByFullName(fullName);
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message,
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SelectRowByFullName(string fullName)
        {
            foreach (DataGridViewRow row in dataGridViewStudents.Rows)
            {
                if (row.Cells["FullName"].Value?.ToString() == fullName)
                {
                    row.Selected = true;
                    dataGridViewStudents.CurrentCell = row.Cells[0];
                    FillFieldsFromSelectedRow();
                    break;
                }
            }
        }

        private void buttonUpdate_Click(object? sender, EventArgs e)
        {
            UpdateStudentInternal();
        }

        public bool UpdateStudentInternal()
        {
            if (_selectedId < 0)
            {
                MessageBox.Show("Выберите студента в таблице для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!ValidateInputs())
                return false;

            int updatedId = _selectedId;
            string fullName = textBoxName.Text.Trim();
            int age = (int)numericAge.Value;
            string group = textBoxGroup.Text.Trim();
            double grade = (double)numericGrade.Value;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = @"UPDATE Students
                                   SET FullName = @name,
                                       Age = @age,
                                       GroupName = @group,
                                       AverageGrade = @grade
                                   WHERE Id = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", fullName);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@group", group);
                        cmd.Parameters.AddWithValue("@grade", grade);
                        cmd.Parameters.AddWithValue("@id", updatedId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadStudents($"Запись (Код={updatedId}) обновлена");
                SelectRowByFullName(fullName);
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при обновлении: " + ex.Message,
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void buttonDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedId < 0)
            {
                MessageBox.Show("Выберите студента для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Вы действительно хотите удалить студента «{textBoxName.Text}»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                DeleteSelectedInternal();
            }
        }

        public bool DeleteSelectedInternal()
        {
            if (_selectedId < 0)
                return false;

            int deletedId = _selectedId;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Students WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", deletedId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadStudents($"Запись (Код={deletedId}) удалена");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message,
                    "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void buttonClear_Click(object? sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            _selectedId = -1;
            dataGridViewStudents.ClearSelection();
            textBoxName.Clear();
            numericAge.Value = 18;
            textBoxGroup.Clear();
            numericGrade.Value = 4.00m;
            textBoxName.Focus();
            labelStatus.Text = $"Поля очищены | Всего студентов: {dataGridViewStudents.Rows.Count}";
        }

        private void textBoxSearch_TextChanged(object? sender, EventArgs e)
        {
            string q = textBoxSearch.Text.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
            _studentsTable.DefaultView.RowFilter = string.IsNullOrEmpty(q) ? string.Empty : $"FullName LIKE '%{q}%'";
            labelStatus.Text = $"Найдено: {_studentsTable.DefaultView.Count} | Всего студентов: {_studentsTable.Rows.Count}";
        }

        private void buttonCancel_Click(object? sender, EventArgs e)
        {
            textBoxSearch.Clear();
            LoadStudents("Изменения отменены");
        }

        private void buttonExportCsv_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv",
                FileName = "students_export.csv",
                Title = "Экспорт таблицы студентов в CSV"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExportToCsv(dialog.FileName);
            }
        }

        public void ExportToCsv(string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id;FullName;Age;GroupName;AverageGrade");

            foreach (DataGridViewRow row in dataGridViewStudents.Rows)
            {
                if (row.IsNewRow) continue;
                sb.AppendLine(string.Join(";",
                    row.Cells["Id"].Value,
                    row.Cells["FullName"].Value,
                    row.Cells["Age"].Value,
                    row.Cells["GroupName"].Value,
                    Convert.ToDouble(row.Cells["AverageGrade"].Value).ToString("0.00")));
            }

            File.WriteAllText(filePath, sb.ToString(), new UTF8Encoding(true));
            labelStatus.Text = $"Экспортировано в {Path.GetFileName(filePath)} ({dataGridViewStudents.Rows.Count} зап.) | Всего студентов: {_studentsTable.Rows.Count}";
        }
    }
}
