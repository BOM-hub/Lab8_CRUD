#nullable enable
namespace Lab8_CRUD;

partial class Form1
{
    private System.ComponentModel.IContainer? components = null;

    private System.Windows.Forms.Label labelSearch = null!;
    private System.Windows.Forms.TextBox textBoxSearch = null!;
    private System.Windows.Forms.DataGridView dataGridViewStudents = null!;
    private System.Windows.Forms.GroupBox groupBoxEdit = null!;
    private System.Windows.Forms.Label labelName = null!;
    private System.Windows.Forms.TextBox textBoxName = null!;
    private System.Windows.Forms.Label labelAge = null!;
    private System.Windows.Forms.NumericUpDown numericAge = null!;
    private System.Windows.Forms.Label labelGroup = null!;
    private System.Windows.Forms.TextBox textBoxGroup = null!;
    private System.Windows.Forms.Label labelGrade = null!;
    private System.Windows.Forms.NumericUpDown numericGrade = null!;
    private System.Windows.Forms.Button buttonAdd = null!;
    private System.Windows.Forms.Button buttonUpdate = null!;
    private System.Windows.Forms.Button buttonDelete = null!;
    private System.Windows.Forms.Button buttonClear = null!;
    private System.Windows.Forms.Button buttonCancel = null!;
    private System.Windows.Forms.Label labelStatus = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        labelSearch = new System.Windows.Forms.Label();
        textBoxSearch = new System.Windows.Forms.TextBox();
        dataGridViewStudents = new System.Windows.Forms.DataGridView();
        groupBoxEdit = new System.Windows.Forms.GroupBox();
        labelName = new System.Windows.Forms.Label();
        textBoxName = new System.Windows.Forms.TextBox();
        labelAge = new System.Windows.Forms.Label();
        numericAge = new System.Windows.Forms.NumericUpDown();
        labelGroup = new System.Windows.Forms.Label();
        textBoxGroup = new System.Windows.Forms.TextBox();
        labelGrade = new System.Windows.Forms.Label();
        numericGrade = new System.Windows.Forms.NumericUpDown();
        buttonAdd = new System.Windows.Forms.Button();
        buttonUpdate = new System.Windows.Forms.Button();
        buttonDelete = new System.Windows.Forms.Button();
        buttonClear = new System.Windows.Forms.Button();
        buttonCancel = new System.Windows.Forms.Button();
        labelStatus = new System.Windows.Forms.Label();

        ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
        groupBoxEdit.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericAge).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericGrade).BeginInit();
        SuspendLayout();

        // labelSearch
        labelSearch.AutoSize = true;
        labelSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        labelSearch.Location = new System.Drawing.Point(16, 17);
        labelSearch.Name = "labelSearch";
        labelSearch.Size = new System.Drawing.Size(102, 17);
        labelSearch.Text = "Поиск по ФИО:";

        // textBoxSearch
        textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        textBoxSearch.Location = new System.Drawing.Point(125, 14);
        textBoxSearch.Name = "textBoxSearch";
        textBoxSearch.Size = new System.Drawing.Size(360, 24);
        textBoxSearch.TabIndex = 0;
        textBoxSearch.TextChanged += textBoxSearch_TextChanged;

        // dataGridViewStudents
        dataGridViewStudents.AllowUserToAddRows = false;
        dataGridViewStudents.Anchor = System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
        dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewStudents.BackgroundColor = System.Drawing.SystemColors.Window;
        dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewStudents.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        dataGridViewStudents.Location = new System.Drawing.Point(16, 46);
        dataGridViewStudents.MultiSelect = false;
        dataGridViewStudents.Name = "dataGridViewStudents";
        dataGridViewStudents.ReadOnly = true;
        dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridViewStudents.Size = new System.Drawing.Size(950, 295);
        dataGridViewStudents.TabIndex = 0;
        dataGridViewStudents.SelectionChanged += dataGridViewStudents_SelectionChanged;

        // groupBoxEdit
        groupBoxEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
        groupBoxEdit.Controls.Add(labelName);
        groupBoxEdit.Controls.Add(textBoxName);
        groupBoxEdit.Controls.Add(labelAge);
        groupBoxEdit.Controls.Add(numericAge);
        groupBoxEdit.Controls.Add(labelGroup);
        groupBoxEdit.Controls.Add(textBoxGroup);
        groupBoxEdit.Controls.Add(labelGrade);
        groupBoxEdit.Controls.Add(numericGrade);
        groupBoxEdit.Controls.Add(buttonAdd);
        groupBoxEdit.Controls.Add(buttonUpdate);
        groupBoxEdit.Controls.Add(buttonDelete);
        groupBoxEdit.Controls.Add(buttonClear);
        groupBoxEdit.Controls.Add(buttonCancel);
        groupBoxEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        groupBoxEdit.Location = new System.Drawing.Point(16, 352);
        groupBoxEdit.Name = "groupBoxEdit";
        groupBoxEdit.Size = new System.Drawing.Size(950, 170);
        groupBoxEdit.TabIndex = 1;
        groupBoxEdit.TabStop = false;
        groupBoxEdit.Text = "Данные студента";

        // labelName
        labelName.AutoSize = true;
        labelName.Location = new System.Drawing.Point(18, 32);
        labelName.Name = "labelName";
        labelName.Size = new System.Drawing.Size(42, 17);
        labelName.Text = "ФИО:";

        // textBoxName
        textBoxName.Location = new System.Drawing.Point(125, 29);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new System.Drawing.Size(360, 24);
        textBoxName.TabIndex = 0;

        // labelAge
        labelAge.AutoSize = true;
        labelAge.Location = new System.Drawing.Point(515, 32);
        labelAge.Name = "labelAge";
        labelAge.Size = new System.Drawing.Size(62, 17);
        labelAge.Text = "Возраст:";

        // numericAge
        numericAge.Location = new System.Drawing.Point(615, 29);
        numericAge.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
        numericAge.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
        numericAge.Name = "numericAge";
        numericAge.Size = new System.Drawing.Size(110, 24);
        numericAge.TabIndex = 1;
        numericAge.Value = new decimal(new int[] { 18, 0, 0, 0 });

        // labelGroup
        labelGroup.AutoSize = true;
        labelGroup.Location = new System.Drawing.Point(18, 72);
        labelGroup.Name = "labelGroup";
        labelGroup.Size = new System.Drawing.Size(55, 17);
        labelGroup.Text = "Группа:";

        // textBoxGroup
        textBoxGroup.Location = new System.Drawing.Point(125, 69);
        textBoxGroup.Name = "textBoxGroup";
        textBoxGroup.Size = new System.Drawing.Size(200, 24);
        textBoxGroup.TabIndex = 2;

        // labelGrade
        labelGrade.AutoSize = true;
        labelGrade.Location = new System.Drawing.Point(515, 72);
        labelGrade.Name = "labelGrade";
        labelGrade.Size = new System.Drawing.Size(96, 17);
        labelGrade.Text = "Средний балл:";

        // numericGrade
        numericGrade.DecimalPlaces = 2;
        numericGrade.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        numericGrade.Location = new System.Drawing.Point(615, 69);
        numericGrade.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
        numericGrade.Name = "numericGrade";
        numericGrade.Size = new System.Drawing.Size(110, 24);
        numericGrade.TabIndex = 3;
        numericGrade.Value = new decimal(new int[] { 400, 0, 0, 131072 });

        // buttonAdd
        buttonAdd.Location = new System.Drawing.Point(18, 118);
        buttonAdd.Name = "buttonAdd";
        buttonAdd.Size = new System.Drawing.Size(140, 34);
        buttonAdd.TabIndex = 4;
        buttonAdd.Text = "Добавить";
        buttonAdd.UseVisualStyleBackColor = true;
        buttonAdd.Click += buttonAdd_Click;

        // buttonUpdate
        buttonUpdate.Location = new System.Drawing.Point(170, 118);
        buttonUpdate.Name = "buttonUpdate";
        buttonUpdate.Size = new System.Drawing.Size(140, 34);
        buttonUpdate.TabIndex = 5;
        buttonUpdate.Text = "Обновить";
        buttonUpdate.UseVisualStyleBackColor = true;
        buttonUpdate.Click += buttonUpdate_Click;

        // buttonDelete
        buttonDelete.Location = new System.Drawing.Point(322, 118);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new System.Drawing.Size(140, 34);
        buttonDelete.TabIndex = 6;
        buttonDelete.Text = "Удалить";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += buttonDelete_Click;

        // buttonClear
        buttonClear.Location = new System.Drawing.Point(474, 118);
        buttonClear.Name = "buttonClear";
        buttonClear.Size = new System.Drawing.Size(140, 34);
        buttonClear.TabIndex = 7;
        buttonClear.Text = "Очистить";
        buttonClear.UseVisualStyleBackColor = true;
        buttonClear.Click += buttonClear_Click;

        // buttonCancel
        buttonCancel.Location = new System.Drawing.Point(626, 118);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new System.Drawing.Size(140, 34);
        buttonCancel.TabIndex = 8;
        buttonCancel.Text = "Отмена";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;

        // labelStatus
        labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        labelStatus.AutoSize = true;
        labelStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        labelStatus.Location = new System.Drawing.Point(16, 532);
        labelStatus.Name = "labelStatus";
        labelStatus.Size = new System.Drawing.Size(55, 17);
        labelStatus.Text = "Готово";

        // Form1
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(984, 561);
        Controls.Add(labelStatus);
        Controls.Add(groupBoxEdit);
        Controls.Add(textBoxSearch);
        Controls.Add(labelSearch);
        Controls.Add(dataGridViewStudents);
        Name = "Form1";
        Size = new System.Drawing.Size(1000, 600);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Лабораторная работа №8 — CRUD";
        Load += Form1_Load;

        ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
        groupBoxEdit.ResumeLayout(false);
        groupBoxEdit.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericAge).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericGrade).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
