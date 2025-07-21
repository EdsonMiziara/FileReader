using FileReader.Models.Modelos.Factory;
using FileReader.Models.Modelos.Interface;

namespace FileReader.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void chooseFileButton_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
        {
            folderBrowser.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            folderBrowser.Description = "Selecione a pasta onde os arquivos estão localizados";
            folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowser.ShowNewFolderButton = true;

            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = folderBrowser.SelectedPath;
                
                try
                {
                    string[] files = Directory.GetFiles(filePath);
                    List<IArquivo> arquivos = new List<IArquivo>();

                    foreach (string file in files) 
                    {
                        if (File.Exists(file))
                        {
                            IArquivo arquivo = FileFactory.CriarArquivo(file);
                            if (arquivo != null)
                            {
                                MessageBox.Show(arquivo.ToString());
                                arquivos.Add(arquivo);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao acessar a pasta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma pasta selecionada.");
            }
        }
    }
}
