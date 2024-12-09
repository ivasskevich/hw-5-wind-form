//namespace hw_5_wind_form
//{
//    public partial class Form1 : Form
//    {
//        MenuStrip menuStrip;
//        ToolStripMenuItem fileMenu, optionsMenu;
//        ToolStripMenuItem openFileMenuItem, saveFileMenuItem, exitMenuItem;
//        private ToolStripMenuItem addAuthorMenuItem, deleteAuthorMenuItem, editAuthorMenuItem;
//        ToolStripMenuItem addBookMenuItem, deleteBookMenuItem, editBookMenuItem;
//        bool altPressed = false;

//        List<Author> authors = new List<Author>();
//        List<Book> books = new List<Book>();

//        public Form1()
//        {
//            InitializeComponent();
//            InitializeMenu();
//            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
//            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
//            KeyDown += Form1_KeyDown;
//            KeyUp += Form1_KeyUp;
//        }

//        private void InitializeMenu()
//        {
//            menuStrip = new MenuStrip();
//            fileMenu = new ToolStripMenuItem("&File");

//            openFileMenuItem = new ToolStripMenuItem("Open");
//            openFileMenuItem.Click += OpenFileMenuItem_Click;
//            fileMenu.DropDownItems.Add(openFileMenuItem);

//            saveFileMenuItem = new ToolStripMenuItem("Save");
//            saveFileMenuItem.Click += SaveFileMenuItem_Click;
//            fileMenu.DropDownItems.Add(saveFileMenuItem);

//            exitMenuItem = new ToolStripMenuItem("Exit");
//            exitMenuItem.Click += (s, e) => Close();
//            fileMenu.DropDownItems.Add(exitMenuItem);

//            menuStrip.Items.Add(fileMenu);
//            optionsMenu = new ToolStripMenuItem("&Options");

//            addAuthorMenuItem = new ToolStripMenuItem("Add Author");
//            addAuthorMenuItem.Click += AddAuthorMenuItem_Click;
//            optionsMenu.DropDownItems.Add(addAuthorMenuItem);

//            deleteAuthorMenuItem = new ToolStripMenuItem("Delete Author");
//            deleteAuthorMenuItem.Click += DeleteAuthorMenuItem_Click;
//            optionsMenu.DropDownItems.Add(deleteAuthorMenuItem);

//            editAuthorMenuItem = new ToolStripMenuItem("Edit Author");
//            editAuthorMenuItem.Click += EditAuthorMenuItem_Click;
//            optionsMenu.DropDownItems.Add(editAuthorMenuItem);

//            addBookMenuItem = new ToolStripMenuItem("Add Book");
//            addBookMenuItem.Click += AddBookMenuItem_Click;
//            optionsMenu.DropDownItems.Add(addBookMenuItem);

//            deleteBookMenuItem = new ToolStripMenuItem("Delete Book");
//            deleteBookMenuItem.Click += DeleteBookMenuItem_Click;
//            optionsMenu.DropDownItems.Add(deleteBookMenuItem);

//            editBookMenuItem = new ToolStripMenuItem("Edit Book");
//            editBookMenuItem.Click += EditBookMenuItem_Click;
//            optionsMenu.DropDownItems.Add(editBookMenuItem);

//            menuStrip.Items.Add(optionsMenu);

//            Controls.Add(menuStrip);
//            MainMenuStrip = menuStrip;
//        }

//        private void OpenFileMenuItem_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog openFileDialog = new OpenFileDialog
//            {
//                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
//            };

//            if (openFileDialog.ShowDialog() == DialogResult.OK)
//            {
//                LoadDataFromFile(openFileDialog.FileName);
//            }
//        }

//        private void SaveFileMenuItem_Click(object sender, EventArgs e)
//        {
//            SaveFileDialog saveFileDialog = new SaveFileDialog
//            {
//                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
//            };

//            if (saveFileDialog.ShowDialog() == DialogResult.OK)
//            {
//                SaveDataToFile(saveFileDialog.FileName);
//            }
//        }

//        private void AddAuthorMenuItem_Click(object sender, EventArgs e)
//        {
//            var author = new Author();
//            var form = new Form2(author, true);

//            if (form.ShowDialog() == DialogResult.OK)
//            {
//                authors.Add(author);
//                UpdateAuthorList();
//                comboBox1.SelectedItem = author;
//            }
//        }

//        private void DeleteAuthorMenuItem_Click(object sender, EventArgs e)
//        {
//            if (comboBox1.SelectedItem is not Author selectedAuthor)
//                return;

//            if (MessageBox.Show("Delete author and all their books?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
//            {
//                books.RemoveAll(b => b.Author == selectedAuthor);
//                authors.Remove(selectedAuthor);

//                if (comboBox1.SelectedItem == selectedAuthor)
//                {
//                    comboBox1.SelectedItem = null;
//                }

//                UpdateAuthorList();
//                UpdateBookList();
//            }
//        }

//        private void EditAuthorMenuItem_Click(object sender, EventArgs e)
//        {
//            if (comboBox1.SelectedItem is not Author selectedAuthor)
//            {
//                MessageBox.Show("Please select an author to edit.");
//                return;
//            }

//            var form = new Form2(selectedAuthor, false);
//            if (form.ShowDialog() == DialogResult.OK)
//            {
//                UpdateAuthorList();
//                comboBox1.SelectedItem = selectedAuthor;
//            }
//        }

//        private void AddBookMenuItem_Click(object sender, EventArgs e)
//        {
//            if (comboBox1.SelectedItem is not Author selectedAuthor)
//            {
//                MessageBox.Show("Please select an author before adding a book.");
//                return;
//            }

//            var book = new Book { Author = selectedAuthor };
//            var form = new Form3(book, authors, true);

//            if (form.ShowDialog() == DialogResult.OK)
//            {
//                books.Add(book);
//                selectedAuthor.Books.Add(book);
//                UpdateBookList();
//            }
//        }

//        private void DeleteBookMenuItem_Click(object sender, EventArgs e)
//        {
//            if (listBox1.SelectedItem is not Book selectedBook)
//            {
//                MessageBox.Show("Please select a book to delete.");
//                return;
//            }

//            if (MessageBox.Show("Delete this book?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
//            {
//                books.Remove(selectedBook);
//                selectedBook.Author.Books.Remove(selectedBook);

//                UpdateBookList();
//            }
//        }


//        private void EditBookMenuItem_Click(object sender, EventArgs e)
//        {
//            if (listBox1.SelectedItem is not Book selectedBook)
//            {
//                MessageBox.Show("Please select a book to edit.");
//                return;
//            }

//            var form = new Form3(selectedBook, authors, false);

//            if (form.ShowDialog() == DialogResult.OK)
//            {
//                UpdateBookList();
//            }
//        }

//        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
//        {
//            UpdateBookList();
//        }

//        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (checkBox1.Checked)
//            {
//                UpdateBookList();
//            }
//        }

//        private void UpdateAuthorList()
//        {
//            comboBox1.Items.Clear();
//            comboBox1.Items.AddRange(authors.ToArray());

//            EnsureAuthorSelected();
//        }

//        private void EnsureAuthorSelected()
//        {
//            if (authors.Any())
//            {
//                comboBox1.SelectedItem ??= authors.First();
//            }
//        }


//        private void UpdateBookList()
//        {
//            listBox1.Items.Clear();

//            if (checkBox1.Checked && comboBox1.SelectedItem is Author selectedAuthor)
//            {
//                listBox1.Items.AddRange(books.Where(b => b.Author == selectedAuthor).ToArray());
//            }
//            else
//            {
//                listBox1.Items.AddRange(books.ToArray());
//            }

//            listBox1.DisplayMember = "Title";
//        }


//        private void LoadDataFromFile(string fileName)
//        {
//            authors.Clear();
//            books.Clear();

//            var lines = File.ReadAllLines(fileName);
//            Author currentAuthor = null;

//            foreach (var line in lines)
//            {
//                if (line.StartsWith("Author:"))
//                {
//                    currentAuthor = new Author(line.Substring(7).Trim());
//                    authors.Add(currentAuthor);
//                }
//                else if (line.StartsWith("Book:") && currentAuthor != null)
//                {
//                    var book = new Book(line.Substring(5).Trim(), currentAuthor);
//                    books.Add(book);
//                    currentAuthor.Books.Add(book);
//                }
//            }

//            UpdateAuthorList();
//            UpdateBookList();
//        }

//        private void SaveDataToFile(string fileName)
//        {
//            var lines = new List<string>();

//            foreach (var author in authors)
//            {
//                lines.Add("Author: " + author.Name);
//                foreach (var book in author.Books)
//                {
//                    lines.Add("Book: " + book.Title);
//                }
//            }

//            File.WriteAllLines(fileName, lines);
//        }
//        private void Form1_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Menu && !altPressed)
//            {
//                altPressed = true;
//                Refresh();
//            }
//        }

//        private void Form1_KeyUp(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Menu && altPressed)
//            {
//                altPressed = false;
//                Refresh();
//            }
//        }
//    }

//    public class Author
//    {
//        public string Name { get; set; }
//        public List<Book> Books { get; set; } = new List<Book>();
//        public Author() { }

//        public Author(string name)
//        {
//            Name = name;
//        }

//        public override string ToString()
//        {
//            return Name;
//        }
//    }

//    public class Book
//    {
//        public string Title { get; set; }
//        public Author Author { get; set; }
//        public Book() { }

//        public Book(string title, Author author)
//        {
//            Title = title;
//            Author = author;
//        }

//        public override string ToString()
//        {
//            return Title + " (Author: " + Author.Name + ")";
//        }
//    }
//}

namespace hw_5_wind_form
{
    public partial class Form1 : Form
    {
        private MenuStrip menu;
        private ToolStripMenuItem fileOption, settingsOption;
        private ToolStripMenuItem openAction, saveAction, exitAction;
        private ToolStripMenuItem addNewAuthor, removeAuthor, modifyAuthor;
        private ToolStripMenuItem addNewBook, removeBook, modifyBook;
        private bool isAltKeyPressed = false;

        private List<Author> authorList = new List<Author>();
        private List<Book> bookList = new List<Book>();

        public Form1()
        {
            InitializeComponent();
            SetupMenu();
            checkBox1.CheckedChanged += AuthorSelectionChanged;
            comboBox1.SelectedIndexChanged += DisplayBooksCheckBoxChanged;
            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
        }

        private void SetupMenu()
        {
            menu = new MenuStrip();
            fileOption = new ToolStripMenuItem("File");

            openAction = new ToolStripMenuItem("Open");
            openAction.Click += OpenFileAction_Click;
            fileOption.DropDownItems.Add(openAction);

            saveAction = new ToolStripMenuItem("Save");
            saveAction.Click += SaveFileAction_Click;
            fileOption.DropDownItems.Add(saveAction);

            exitAction = new ToolStripMenuItem("Exit");
            exitAction.Click += (sender, e) => Close();
            fileOption.DropDownItems.Add(exitAction);

            menu.Items.Add(fileOption);

            settingsOption = new ToolStripMenuItem("Settings");

            addNewAuthor = new ToolStripMenuItem("Add Author");
            addNewAuthor.Click += AddAuthorAction_Click;
            settingsOption.DropDownItems.Add(addNewAuthor);

            removeAuthor = new ToolStripMenuItem("Remove Author");
            removeAuthor.Click += RemoveAuthorAction_Click;
            settingsOption.DropDownItems.Add(removeAuthor);

            modifyAuthor = new ToolStripMenuItem("Edit Author");
            modifyAuthor.Click += EditAuthorAction_Click;
            settingsOption.DropDownItems.Add(modifyAuthor);

            addNewBook = new ToolStripMenuItem("Add Book");
            addNewBook.Click += AddBookAction_Click;
            settingsOption.DropDownItems.Add(addNewBook);

            removeBook = new ToolStripMenuItem("Remove Book");
            removeBook.Click += RemoveBookAction_Click;
            settingsOption.DropDownItems.Add(removeBook);

            modifyBook = new ToolStripMenuItem("Edit Book");
            modifyBook.Click += EditBookAction_Click;
            settingsOption.DropDownItems.Add(modifyBook);

            menu.Items.Add(settingsOption);

            Controls.Add(menu);
            MainMenuStrip = menu;
        }

        private void OpenFileAction_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                LoadDataFromFile(openDialog.FileName);
            }
        }

        private void SaveFileAction_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                SaveDataToFile(saveDialog.FileName);
            }
        }

        private void AddAuthorAction_Click(object sender, EventArgs e)
        {
            var newAuthor = new Author();
            var authorForm = new Form2(newAuthor, true);

            if (authorForm.ShowDialog() == DialogResult.OK)
            {
                authorList.Add(newAuthor);
                RefreshAuthorList();
                comboBox1.SelectedItem = newAuthor;
            }
        }

        private void RemoveAuthorAction_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not Author selectedAuthor) return;

            if (MessageBox.Show("Are you sure you want to delete this author and their books?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bookList.RemoveAll(book => book.Author == selectedAuthor);
                authorList.Remove(selectedAuthor);

                if (comboBox1.SelectedItem == selectedAuthor)
                    comboBox1.SelectedItem = null;

                RefreshAuthorList();
                RefreshBookList();
            }
        }

        private void EditAuthorAction_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not Author selectedAuthor)
            {
                MessageBox.Show("Please select an author first.");
                return;
            }

            var authorForm = new Form2(selectedAuthor, false);
            if (authorForm.ShowDialog() == DialogResult.OK)
            {
                RefreshAuthorList();
                comboBox1.SelectedItem = selectedAuthor;
            }
        }

        private void AddBookAction_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not Author selectedAuthor)
            {
                MessageBox.Show("Select an author before adding a book.");
                return;
            }

            var newBook = new Book { Author = selectedAuthor };
            var bookForm = new Form3(newBook, authorList, true);

            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                bookList.Add(newBook);
                selectedAuthor.Books.Add(newBook);
                RefreshBookList();
            }
        }

        private void RemoveBookAction_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is not Book selectedBook)
            {
                MessageBox.Show("Select a book to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this book?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bookList.Remove(selectedBook);
                selectedBook.Author.Books.Remove(selectedBook);
                RefreshBookList();
            }
        }

        private void EditBookAction_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is not Book selectedBook)
            {
                MessageBox.Show("Select a book to edit.");
                return;
            }

            var bookForm = new Form3(selectedBook, authorList, false);
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                RefreshBookList();
            }
        }

        private void DisplayBooksCheckBoxChanged(object sender, EventArgs e)
        {
            RefreshBookList();
        }

        private void AuthorSelectionChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                RefreshBookList();
            }
        }

        private void RefreshAuthorList()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(authorList.ToArray());

            EnsureAuthorSelected();
        }

        private void EnsureAuthorSelected()
        {
            if (authorList.Any())
            {
                comboBox1.SelectedItem ??= authorList.First();
            }
        }

        private void RefreshBookList()
        {
            listBox1.Items.Clear();

            if (checkBox1.Checked && comboBox1.SelectedItem is Author selectedAuthor)
            {
                listBox1.Items.AddRange(bookList.Where(book => book.Author == selectedAuthor).ToArray());
            }
            else
            {
                listBox1.Items.AddRange(bookList.ToArray());
            }

            listBox1.DisplayMember = "Title";
        }

        private void LoadDataFromFile(string filePath)
        {
            authorList.Clear();
            bookList.Clear();

            var lines = File.ReadAllLines(filePath);
            Author currentAuthor = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("Author:"))
                {
                    currentAuthor = new Author(line.Substring(7).Trim());
                    authorList.Add(currentAuthor);
                }
                else if (line.StartsWith("Book:") && currentAuthor != null)
                {
                    var newBook = new Book(line.Substring(5).Trim(), currentAuthor);
                    bookList.Add(newBook);
                    currentAuthor.Books.Add(newBook);
                }
            }

            RefreshAuthorList();
            RefreshBookList();
        }

        private void SaveDataToFile(string filePath)
        {
            var lines = new List<string>();

            foreach (var author in authorList)
            {
                lines.Add("Author: " + author.Name);
                foreach (var book in author.Books)
                {
                    lines.Add("Book: " + book.Title);
                }
            }

            File.WriteAllLines(filePath, lines);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Menu && !isAltKeyPressed)
            {
                isAltKeyPressed = true;
                Refresh();
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Menu && isAltKeyPressed)
            {
                isAltKeyPressed = false;
                Refresh();
            }
        }
    }

    public class Author
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public Author() { }

        public Author(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }

        public Book() { }

        public Book(string title, Author author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} (by {Author.Name})";
        }
    }
}
