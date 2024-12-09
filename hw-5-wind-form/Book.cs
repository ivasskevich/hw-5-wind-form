namespace hw_5_wind_form
{
    public class Form3 : Form
    {
        private Book book;
        private List<Author> authors;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private bool isNew;

        public Form3(Book book, List<Author> authors, bool isNew)
        {
            InitializeComponent();
            this.book = book;
            this.isNew = isNew;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            Text = isNew ? "Add Book" : "Edit Book";
            textBox1.Text = isNew ? string.Empty : book.Title;

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Book title cannot be empty.");
                return;
            }

            book.Title = textBox1.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Input book";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(284, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(12, 67);
            button1.Name = "button1";
            button1.Size = new Size(85, 32);
            button1.TabIndex = 2;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(211, 67);
            button2.Name = "button2";
            button2.Size = new Size(85, 32);
            button2.TabIndex = 3;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            ClientSize = new Size(308, 111);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}
