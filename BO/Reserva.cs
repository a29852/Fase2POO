using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Representa uma reserva do alojamento onde contem informações como o cliente, alojamento e datas de início e fim.
    /// </summary>
    [Serializable]
    public class Reserva : IInterfaces, IComparable<Reserva>
    {
        #region ATRIBUTOS

        /// <summary>
        /// Atributos da classe Reserva
        /// </summary>

        int id = 0;
        int idCliente;
        int numAloj;
        DateTime dataInicio;
        DateTime dataFim;
        [NonSerialized]
        bool checkIn;

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Inicializa uma nova instância da classe Reserva
        /// </summary>
        /// <param name="id">id da reserva</param>
        /// <param name="idCliente">Id do cliente associado à reserva</param>
        /// <param name="numAloj">Número do alojamento reservado</param>
        /// <param name="dataFim">Data de término da reserva.</param>
        public Reserva(int id, int idCliente, int numAloj, DateTime dataFim)
        {
            this.id = id;
            this.idCliente = idCliente;
            this.numAloj = numAloj;
            dataInicio = DateTime.Now;
            this.dataFim = dataFim;
            this.checkIn = false;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Obtém ou define o Id da reserva
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Obtém ou define o Id do cliente associado à reserva
        /// </summary>
        public int IdCliente
        {
            get
            {
                return idCliente;
            }
            set
            {
                idCliente = value;
            }
        }

        /// <summary>
        /// Obtém ou define o número do alojamento reservado
        /// </summary>
        public int NumAloj
        {
            get
            {
                return numAloj;
            }
            set
            {
                numAloj = value;
            }
        }

        /// <summary>
        /// Obtém ou define a data de início da reserva
        /// </summary>
        public DateTime DataInicio
        {
            get
            {
                return dataInicio;
            }
            set
            {
                dataInicio = value;
            }
        }

        /// <summary>
        /// Obtém ou define a data de fim da reserva
        /// </summary>
        public DateTime DataFim
        {
            get
            {
                return dataFim;
            }
            set
            {
                dataFim = value;
            }
        }

        /// <summary>
        /// Obtém ou define o estado do check-in
        /// </summary>
        public bool CheckIn
        {
            get
            {
                return checkIn;
            }
            set
            {
                checkIn = value;
            }
        }

        #endregion

        /// <summary>
        /// Verifica se o objeto atual é igual ao outro objeto
        /// </summary>
        /// <param name="obj">Objeto a ser comparado</param>
        /// <returns>True se os objetos forem iguais</returns>
        public override bool Equals(object obj)
        {
            if (obj is Reserva)
            {
                Reserva r = (Reserva)obj;

                if (this.idCliente == r.idCliente || this.dataFim == r.dataFim)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Retorna uma representação textual do objeto Reserva
        /// </summary>
        /// <returns>String contendo o id do cliente e o numero do alojamento</returns>
        public override string ToString()
        {
            return $"Id: {Id}, Cliente: {IdCliente}, Alojamento: {NumAloj}";
        }

        /// <summary>
        /// Compara a instância atual com outra reserva com base na data de fim
        /// </summary>
        /// <param name="r">Reserva a ser comparada</param>
        public int CompareTo(Reserva r)
        {
            return dataFim.CompareTo(r.dataFim);
        }
    }
}
