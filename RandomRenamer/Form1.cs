using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Net;

namespace RandomRenamer
{
    public partial class Form1 : Form
    {
        private string sourceFolderPath;

        private List<string> generatedFileNames = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Color color1 = Color.FromArgb(25, 25, 112);
            Color color2 = Color.FromArgb(255, 99, 71);


            LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle, color1, color2, LinearGradientMode.Horizontal);


            e.Graphics.FillRectangle(brush, this.ClientRectangle);

            brush.Dispose();
        }
        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    sourceFolderPath = folderDialog.SelectedPath;
                    statusLabel.Text = $"Selected folder: {sourceFolderPath}";
                    statusLabel.Visible = true;
                }
            }
        }
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void RenameFilesButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sourceFolderPath))
            {
                MessageBox.Show("Please select a folder first.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["pay"].ConnectionString;

            string[] files = Directory.GetFiles(sourceFolderPath);

            progressBar.Maximum = files.Length;
            progressBar.Value = 0;
            progressBar.Visible = true;

            // Load existing filenames into the generatedFileNames list
            generatedFileNames.Clear();
            foreach (string filePath in files)
            {
                string originalFileName = Path.GetFileName(filePath);
                generatedFileNames.Add(originalFileName);
            }

            foreach (string filePath in files)
            {
                string originalFileName = Path.GetFileName(filePath);
                string fileExtension = Path.GetExtension(originalFileName);
                byte[] imageBytes = DownloadImage("https://i.pravatar.cc/300");

                string randomName, randomSurname, randomEmail, newFileName, randomJob, randomSalary;

                int randomDays;

                DateTime datum;

                do
                {
                    randomDays = GetRandomVicationDays();
                    randomSalary = GetRandomSalary();
                    randomJob = GetRandomJob();
                    randomName = GetRandomName();
                    randomSurname = GetRandomSurname();
                    randomEmail = $"{randomName}.{randomSurname}@gmail.com".ToLower();
                    newFileName = $"{randomName}_{randomSurname}_Plata{fileExtension}";
                    datum = GenerateRandomEmploymentDate();

                    progressBar.Value = Math.Min(progressBar.Value + 1, progressBar.Maximum);
                    Application.DoEvents();

                } while (generatedFileNames.Contains(newFileName));

                generatedFileNames.Add(newFileName); 

                string newFilePath = Path.Combine(sourceFolderPath, newFileName);

                File.Move(filePath, newFilePath);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

              

                    string insertQuery = "INSERT INTO Zaposleni (Ime, Prezime, Email, PreostaliDaniOdmora, Plata, Pozicija, DatumZaposlenja, Slika) VALUES (@Ime, @Prezime, @Email, @PreostaliDaniOdmora, @Plata, @Pozicija, @DatumZaposlenja, @Slika)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("Ime", randomName);
                        command.Parameters.AddWithValue("Prezime", randomSurname);
                        command.Parameters.AddWithValue("Email", randomEmail);
                        command.Parameters.AddWithValue("Pozicija", randomJob);
                        command.Parameters.AddWithValue("PreostaliDaniOdmora", randomDays.ToString());
                        command.Parameters.AddWithValue("Plata", randomSalary);
                        command.Parameters.AddWithValue("DatumZaposlenja", datum);
                        command.Parameters.AddWithValue("Slika", imageBytes);


                        command.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Files renamed and added to database successfully.");
            progressBar.Visible = false;
        }

        private byte[] DownloadImage(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }


        private int GetRandomVicationDays()
        {
            int randomValue = new Random().Next(1, 61);
            return randomValue;


        }

        private string GetRandomSalary()
        {
            string[] names = {"100 000", "150 000", "120 000", "200 000", "250 000"

};

            Random random = new Random();
            return names[random.Next(names.Length)];
        }

        private string GetRandomJob()
        {
            string[] names = {"Programer", "Racunovodja", "Menadzer"
   
};

            Random random = new Random();
            return names[random.Next(names.Length)];
        }

        private DateTime GenerateRandomEmploymentDate()
        {
            Random random = new Random();
            DateTime startDate = new DateTime(2000, 1, 1); 
            int range = (DateTime.Today - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }
        private string GetRandomName()
        {
            string[] names = {
    "John", "Emma", "Sophia", "Liam", "Olivia", "Noah", "Isabella", "Oliver", "Mia", "Ava",
    "Mateo", "Luna", "Lucas", "Aria", "Alexander", "Amelia", "Mason", "Harper", "Ethan", "Evelyn",
    "Muhammad", "Sofia", "Sebastian", "Camila", "Jackson", "Avery", "Carter", "Layla", "Aiden", "Scarlett",
    "Matthew", "Chloe", "David", "Zoe", "Leo", "Riley", "Daniel", "Grace", "Joseph", "Penelope",
    "Samuel", "Victoria", "Henry", "Aubrey", "Jack", "Nora", "Gabriel", "Eleanor", "Benjamin", "Scarlet",
    "William", "Hazel", "Elijah", "Lily", "James", "Ellie", "Michael", "Stella", "Alexander", "Maya",
    "Daniel", "Natalie", "Matthew", "Zara", "Nicholas", "Sophie", "Aidan", "Anna", "Ethan", "Lucia",
    "Nathan", "Aria", "Christopher", "Valentina", "Andrew", "Lila", "Joseph", "Isla", "Joshua", "Violet",
    "Sebastian", "Zoe", "Logan", "Nora", "Samuel", "Emilia", "William", "Alice", "Lucas", "Emma",
    "Jayden", "Sophie", "Dylan", "Chloe", "Luke", "Isabelle", "Caleb", "Mila", "Owen", "Luna",
    "Ryan", "Harper", "Nathan", "Gianna", "Isaac", "Avery", "Eli", "Aubrey", "Levi", "Zoey","Lucas", "Emma", "Jayden", "Sophie", "Dylan", "Chloe", "Luke", "Isabelle", "Caleb", "Mila",
    "Owen", "Luna", "Ryan", "Harper", "Nathan", "Gianna", "Isaac", "Avery", "Eli", "Aubrey",
    "Levi", "Zoey", "Mateo", "Victoria", "Diego", "Elena", "Adam", "Nora", "Damian", "Naomi",
    "Max", "Mia", "Leo", "Layla", "Ezra", "Aria", "Hudson", "Scarlett", "Elias", "Zara",
    "Nicholas", "Hazel", "Jameson", "Lily", "Lincoln", "Ellie", "Evan", "Aurora", "Connor", "Addison",
    "Henry", "Paisley", "Jacob", "Brooklyn", "Christopher", "Everly", "Cameron", "Madelyn", "John", "Grace",
    "Julian", "Audrey", "Grayson", "Aaliyah", "Aiden", "Skylar", "Robert", "Nevaeh", "Muhammad", "Genesis",
    "Benjamin", "Serenity", "Joshua", "Harmony", "Joseph", "Naomi", "Daniel", "Valentina", "Anthony", "Alexa",
    "Michael", "Bella", "William", "Caroline", "Matthew", "Katherine", "David", "Kylie", "Ethan", "Maya",
    "Alexander", "Melanie", "Oliver", "Aubree", "Sebastian", "Alice", "Jackson", "Eva", "Levi", "Taylor",
    "Samuel", "Leah", "David", "Sarah", "Joseph", "Aria", "James", "Sadie", "Andrew", "Stella",
    "Benjamin", "Gabriella", "Logan", "Skylar", "Henry", "Zoey", "Nicholas", "Bella", "Jack", "Liliana",
    "Nathan", "Emily", "William", "Lila", "Isaac", "Lily", "Eli", "Grace", "Aiden", "Ellie"
};

            Random random = new Random();
            return names[random.Next(names.Length)];
        }

        private string GetRandomSurname()
        {
            string[] surnames = {
    "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Martinez", "Lopez",
    "Gonzalez", "Rodriguez", "Perez", "Wilson", "Turner", "White", "Walker", "Hall", "Young", "Scott",
    "King", "Hill", "Green", "Adams", "Baker", "Nelson", "Carter", "Mitchell", "Roberts", "Cook",
    "Cooper", "Richardson", "Wood", "Watson", "Gray", "Murphy", "Rogers", "Stewart", "Sanchez", "Ramirez",
    "Reed", "Bailey", "Bryant", "Russell", "Powell", "Long", "Foster", "Sanders", "Ross", "Morales",
    "Brooks", "Perry", "Butler", "Barnes", "Fisher", "Henderson", "Coleman", "Simmons", "Patterson", "Jordan",
    "Reynolds", "Hamilton", "Griffin", "Diaz", "Hayes", "Myers", "Ford", "Hamilton", "Graham", "Sullivan",
    "Wallace", "Fields", "Reyes", "Fox", "Cruz", "Stone", "Washington", "Cox", "Bryant", "Henry",
    "Lopez", "Hayes", "Sanders", "Price", "Barnes", "Roberts", "Cole", "Foster", "Griffin", "Diaz",
    "Ramirez", "Alexander", "Gray", "Brooks", "Bell", "Stewart", "Murphy", "Ward", "Powell", "Peterson",
    "Bryant", "Robinson", "Cox", "Cook", "Carter", "Hill", "Wood", "Morales", "Rogers", "Parker","Allen", "Harrison", "Kennedy", "Wells", "Ford", "Tran", "Yang", "Zhang", "Liu", "Chen",
    "Wang", "Huang", "Fischer", "Klein", "Weber", "Hofmann", "Muller", "Wagner", "Schmidt", "Schneider",
    "Bauer", "Keller", "Schuster", "Braun", "Kuhn", "Pohl", "Lang", "Engel", "Simon", "Kruger",
    "Berger", "Fuchs", "Lang", "Koch", "Mayr", "Vogel", "Peters", "Grunwald", "Egger", "Schmid",
    "Huber", "Neumann", "Lange", "Becker", "Klein", "Leblanc", "Dubois", "Lambert", "Rousseau", "Girard",
    "Bernard", "Roy", "Fortin", "Gagnon", "Pelletier", "Morin", "Lavoie", "Simard",
    "Leclerc", "Boucher", "St-Pierre", "Bertrand", "Cormier", "Lapointe", "Dufresne", "Gagnier", "Rochon",
    "Larose", "Tremblay", "Lemieux", "Perron", "Dupuis", "Beaulieu", "Desjardins", "Allard", "Boivin", "Marchand",
    "Lacoste", "Vaillancourt", "Lefebvre", "Leblanc", "Landry", "Paquette", "Roy", "Thibault", "Poirier",
    "Cormier", "Lalonde", "Fournier", "Caron", "Lacroix", "Ouellet", "Mercier",
    "Benoit", "Lefebvre", "Desrosiers", "Plante", "Poulin", "Beauchemin", "Bouchard",  "Racine",
    "Dubois", "Hamel", "Lavoie", "Leclerc", "Martel", "Rochon", "Savard", "St-Pierre",
    "Tremblay", "Turcotte", "Vachon", "Caron", "Cloutier",  "Dion", "Fontaine", "Gagnon", "Girard"
};

            Random random = new Random();
            return surnames[random.Next(surnames.Length)];
        }


    }
}
