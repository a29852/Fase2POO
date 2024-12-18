using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Representa um alojamento
    /// A classe contém informações como número, tipo, localização, preço por noite e disponibilidade
    /// Implementa a interface IComparable para permitir comparação entre objetos
    /// </summary>
    [Serializable]
    public class Alojamento : IInterfaces, IComparable<Alojamento>
    {
        #region ATRIBUTOS

        /// <summary>
        /// Atributos da classe Alojamento
        /// </summary>

        int numero;
        string tipo;
        string localizacao;
        double precoNoite;
        bool disponivel;
        #endregion


        #region CONSTRUTOR

        /// <summary>
        /// Construtor para inicializar uma nova instância da classe Alojamento
        /// </summary>
        /// <param name="numero">Número único do alojamento</param>
        /// <param name="tipo">Tipo de alojamento (ex.: casa, apartamento)</param>
        /// <param name="localizacao">Localização do alojamento</param>
        /// <param name="precoNoite">Preço por noite do alojamento</param>
        /// <param name="disponivel">Disponibilidade do alojamento</param>
        public Alojamento(int numero, string tipo, string localizacao, double precoNoite, bool disponivel)
        {
            this.numero = numero;
            this.tipo = tipo;
            this.localizacao = localizacao;
            this.precoNoite = precoNoite;
            this.disponivel = disponivel;
        }

        #endregion


        #region PROPRIEDADES
        /// <summary>
        /// Obtém ou define o número do alojamento
        /// </summary>
        public int Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }

        /// <summary>
        /// Obtém ou define o tipo de alojamento
        /// </summary>
        public string Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }

        /// <summary>
        /// Obtém ou define a localização
        /// </summary>
        public string Localizacao
        {
            get
            {
                return localizacao;
            }
            set
            {
                localizacao = value;
            }
        }

        /// <summary>
        /// Obtém ou define o preço por noite
        /// </summary>
        public double PrecoNoite
        {
            get
            {
                return precoNoite;
            }
            set
            {
                precoNoite = value;
            }
        }

        /// <summary>
        /// Obtém ou define a disponibilidade
        /// </summary>
        public bool Disponivel
        {
            get
            {
                return disponivel;
            }
            set
            {
                disponivel = value;
            }
        }

        #endregion

        /// <summary>
        /// Determina se dois objetos do tipo Alojamento são iguais com base no número ou localização
        /// </summary>
        /// <param name="obj">Objeto a ser comparado</param>
        /// <returns>True se os alojamentos forem considerados iguais</returns>
        public override bool Equals(object obj)
        {
            if (obj is Alojamento)
            {
                Alojamento a = (Alojamento)obj;

                if (this.numero == a.numero || this.localizacao == a.localizacao)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Retorna uma representação textual do objeto Alojamento
        /// </summary>
        /// <returns>String contendo o número e a localização</returns>
        public override string ToString()
        {
            return $"Número: {Numero}, Localizacao: {Localizacao}";
        }

        /// <summary>
        /// Compara dois objetos do tipo Alojamento com base no número.
        /// </summary>
        /// <param name="a">Outro objeto do tipo Alojamento a ser comparado</param>
        public int CompareTo(Alojamento a)
        {
            return numero.CompareTo(a.numero);
        }
    }
}
