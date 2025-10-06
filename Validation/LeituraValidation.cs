using Hesol.ModelAux;
using Hesol.Models;

namespace Hesol.Validation
{
    public class LeituraValidation
    {
        public Leitura Analise(LeituraAux leituraAux)
        {
            int pontos = 0;

            if (leituraAux != null)
            {
                //Temperatura
                if (leituraAux.Temperatura > 18 && leituraAux.Temperatura < 25)
                {
                    pontos += 25;
                }
                else if (leituraAux.Temperatura > 10 && leituraAux.Temperatura < 17 || leituraAux.Temperatura > 26 && leituraAux.Temperatura < 32)
                {
                    pontos += 15;
                }
                else
                {
                    pontos += 5;
                }

                //CO2
                if (leituraAux.Co2 <= 800)
                {
                    pontos += 25;
                }
                else if (leituraAux.Co2 > 800 && leituraAux.Co2 < 1000)
                {
                    pontos += 15;
                }
                else
                {
                    pontos += 5;
                }

                //Umidade
                if (leituraAux.Umidade > 40 && leituraAux.Umidade < 70)
                {
                    pontos += 25;
                }
                else if (leituraAux.Umidade > 30 && leituraAux.Temperatura < 39 || leituraAux.Temperatura > 71 && leituraAux.Temperatura < 80)
                {
                    pontos += 15;
                }
                else
                {
                    pontos += 5;
                }

                //Poluição
                if (leituraAux.Poluicao > 0 && leituraAux.Poluicao < 50)
                {
                    pontos += 25;
                }
                else if (leituraAux.Poluicao > 50 && leituraAux.Temperatura < 100 || leituraAux.Temperatura > 71 && leituraAux.Temperatura < 80)
                {
                    pontos += 15;
                }
                else
                {
                    pontos += 5;
                }

            }

            string resultado = "";

            if (pontos > 85 && pontos <= 100)
            {
                resultado = "Excelente";
            }
            if (pontos > 60 && pontos <= 85)
            {
                resultado = "Boa";
            }
            if (pontos > 40 && pontos <= 60)
            {
                resultado = "Moderada";
            }
            if (pontos > 20 && pontos <= 40)
            {
                resultado = "Ruim";
            }
            if (pontos <= 20)
            {
                resultado = "Péssimo";
            }
            Console.WriteLine("Resultado:" + resultado);
            Leitura leitura = new Leitura(leituraAux.IdLeitura, leituraAux.IdUsuario, leituraAux.IdSensor, leituraAux.Temperatura, leituraAux.Co2, leituraAux.Umidade, leituraAux.Poluicao, resultado);

            return leitura;

        }
    }
}
