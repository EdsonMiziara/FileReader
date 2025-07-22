using FileReader.Forms.Services.Abstracoes;

namespace FileReader.Forms.Services;

public class LeitorArquivoPdf : ILeitorDeArquivos
{
    private string caminhoArquivo;
    public LeitorArquivoPdf(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }
    public string RealizaLeitura()
    {
            using var stream = new StreamReader(caminhoArquivo);
            string texto = stream.ReadToEnd();

            return texto;

    }
}
