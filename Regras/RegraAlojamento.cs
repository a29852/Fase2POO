using BO;
using Dados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regras
{
    /// <summary>
    /// Classe responsável por fornecer as regras de negócio
    /// Contém métodos que interagem com a camada de dados para gerir os alojamentos
    /// </summary>
    public class RegraAlojamento
    {
        /// <summary>
        /// Tenta registar um novo alojamento no sistema, verificando se ele já existe
        /// </summary>
        /// <param name="a">O alojamento a ser registado</param>
        /// <returns>Retorna true se o alojamento foi registado com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="Exception">Lançada quando ocorre um erro genérico</exception>
        public static bool TentaRegistarAlojamento(Alojamento a)
        {
            try
            {
                if (!Alojamentos.CompararAlojamento(a))
                {
                    Alojamentos.RegistarAlojamentos(a);
                    return true;
                }
                return false;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 |Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Tenta pesquisar um alojamento pelo numero
        /// </summary>
        /// <param name="numero">O numero do alojamento a ser pesquisado</param>
        /// <returns>Retorna o alojamento encontrado</returns>
        /// <exception cref="ArgumentException">Lançada se o numero do alojamento for inválido</exception>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="ApplicationException">Lançada quando ocorre um erro genérico</exception>
        public static Alojamento TentaPequisarAlojamento(int numero)
        {
            try
            {
                if (numero > 0)
                {
                    return Alojamentos.PequisarAlojamento(numero);
                }
                throw new ArgumentException("400");
            }
            catch (ArgumentException ex)
            {
                throw new ApplicationException("400 | Erro: " + ex.Message);
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 |Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Tenta obter todos os alojamentos
        /// </summary>
        /// <returns>Retorna uma lista de todos os alojamentos</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        /// <exception cref="Exception">Lançada quando ocorre um erro genérico</exception>
        public static List<Alojamento> TentaTodosAlojamentos()
        {
            try
            {
                return Alojamentos.TodosAlojamentos();

            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("520 |Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Tenta guardar todos os alojamentos em uma pasta especificada
        /// </summary>
        /// <param name="pasta">O caminho da pasta onde os alojamentos serão guradados</param>
        /// <returns>Retorna true se os alojamentos foram salvos com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        public static bool TentaGuardaAlojamentos(string pasta)
        {
            try
            {
                return Reservas.GuardaReservas(pasta);

            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }
        }

        /// <summary>
        /// Tenta carregar os alojamentos a partir de um ficheiro binário localizado na pasta especificada
        /// </summary>
        /// <param name="pasta">O caminho da pasta onde o ficheiro de alojamentos está localizado</param>
        /// <returns>Retorna true se os alojamentos foram carregados com sucesso</returns>
        /// <exception cref="IOException">Lançada quando ocorre um erro de I/O</exception>
        public static bool TentaCarregaAlojamentos(string pasta)
        {
            try
            {
                if (File.Exists(pasta + "\\Alojamentos.bin"))
                {
                    return Alojamentos.CarregaAlojamentos(pasta);
                }
                return false;
            }
            catch (IOException ex)
            {
                throw new IOException("500 | Erro: " + ex.Message);
            }

        }
    }
}
