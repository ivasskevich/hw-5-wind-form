namespace hw_5_wind_form
{
    internal class Form2 : Form
    {
        private Author author;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private bool isNew;

        public Form2(Author author, bool isNew)
        {
            InitializeComponent();
            this.author = author;
            this.isNew = isNew;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            Text = isNew ? "Add Author" : "Edit Author";

            if (!isNew)
            {
                textBox1.Text = author.Name;
            }

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Author name cannot be empty.");
                return;
            }

            author.Name = textBox1.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Input author";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(288, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(12, 65);
            button1.Name = "button1";
            button1.Size = new Size(82, 36);
            button1.TabIndex = 2;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(213, 65);
            button2.Name = "button2";
            button2.Size = new Size(82, 36);
            button2.TabIndex = 3;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            ClientSize = new Size(307, 107);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
