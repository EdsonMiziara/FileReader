namespace FileReader.Models.Modelos.Interface;

public interface IArquivo
{
    public string Caminho { get; }
    public string? Nome { get; }
    public long? Tamanho { get; }
    public string ToString();
}
