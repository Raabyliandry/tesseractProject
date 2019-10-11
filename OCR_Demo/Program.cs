using System;
using Tesseract;

namespace OCR_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var testImagem = @"c:/ocr.png";

            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "por", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImagem))
                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();
                            Console.WriteLine("Taxa de precisão: {0} ",page.GetMeanConfidence());

                            Console.WriteLine("Texto : \r\n{0}", texto);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Erro: {0}", ex.Message);

            }
            finally
            {
                Console.ReadLine();
            }

        }
    }
}
