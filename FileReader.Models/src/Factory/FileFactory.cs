using FileReader.Models.Modelos.Interface;
using FileReader.Models.Modelos.Models;

namespace FileReader.Models.Modelos.Factory;

public class FileFactory
{
    public static IArquivo CriarArquivo(string caminho)
    {
        if (caminho.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
        {
            return new PdfFile(caminho);
        }
        else if (caminho.EndsWith(".docx", StringComparison.OrdinalIgnoreCase) || caminho.EndsWith(".doc", StringComparison.OrdinalIgnoreCase))
        {
            return new WordFile(caminho);
        }
        else
        {
            throw new NotSupportedException("Tipo de arquivo não suportado.");
        }
    }
}
