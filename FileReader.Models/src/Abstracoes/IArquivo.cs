namespace FileReader.Models.Modelos.Abstracoes;

public interface IArquivo
{
    public string Caminho { get; }
    public string? Nome { get; }
    public long? Tamanho { get; }
    public bool Marcado { get; set; }
    public string ToString();
}
