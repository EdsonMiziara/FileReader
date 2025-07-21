using FileReader.Models.Modelos.Interface;

namespace FileReader.Models.Modelos.Models;

public class WordFile : IArquivo
{
    public string Caminho { get; set; }
    public string? Nome { get; private set; }
    public long? Tamanho { get; private set; }

    public WordFile(string caminho)
    {
        Caminho = caminho;
        ValidarProps(Caminho);
    }
    private void ValidarProps(string caminho)
    {
        try
        {
            Nome = Path.GetFileNameWithoutExtension(Caminho);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Caminho inválido para o arquivo PDF.", nameof(caminho), ex);
        }
        try
        {
            FileInfo fileInfo = new FileInfo(Caminho);
            long fileSizeInBytes = fileInfo.Length;

            Tamanho = fileSizeInBytes/1000;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Arquivo não encontrado.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ocorreu um erro: {e.Message}");
        }
    }
    public override string ToString()
    {
        return $"Word Nome: {Nome}, Caminho: {Caminho}, Tamanho: {Tamanho} KB";
    }
}
