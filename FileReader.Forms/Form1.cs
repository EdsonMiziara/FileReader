using FileReader.Models.Modelos.Factory;
using FileReader.Models.Modelos.Abstracoes;
using FileReader.Forms.Services.Abstracoes;
using FileReader.Models.Modelos.Models;
using FileReader.Forms.Services;

namespace FileReader.Forms;

public partial class Form1 : Form
{
    private List<IArquivo> Arquivos;
    private Dictionary<IArquivo, string> ArquivosDictionary;
    public Form1()
    {
        this.Arquivos = new List<IArquivo>();
        this.ArquivosDictionary = new Dictionary<IArquivo, string>();
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
                    string[] arquivos = Directory.GetFiles(filePath);
                    List<IArquivo> arquivosSelecionados = new List<IArquivo>();

                    foreach (string arquivo in arquivos)
                    {
                        if (File.Exists(arquivo))
                        {
                            IArquivo arquivoAtual = FileFactory.CriarArquivo(arquivo);
                            if (arquivoAtual != null)
                            {
                                arquivosSelecionados.Add(arquivoAtual);
                                ArquivosEncontrados.Items.Add(arquivoAtual);
                                ArquivosEncontrados.Items.ToString();
                                var texto = new LeitorArquivoPdf(arquivoAtual.Caminho).RealizaLeitura();
                                ArquivosDictionary.Add(arquivoAtual, texto);  
                                MessageBox.Show(texto);
                            }
                        }
                    }
                    MessageBox.Show($"Aruivos encontrados: {arquivosSelecionados.Count()}");
                    this.Arquivos = arquivosSelecionados;
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

    private void ArquivosEncontrados_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ArquivosEncontrados.CheckedItems.Count > 0)
        {
            foreach (IArquivo arquivo in ArquivosEncontrados.CheckedItems)
            {
                arquivo.Marcado = true;
            }
        }
    }
}
