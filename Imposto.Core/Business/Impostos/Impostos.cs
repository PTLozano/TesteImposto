namespace Imposto.Core.Business.Impostos
{
    /// <summary>
    /// Realiza o calculo do imposto
    /// </summary>
    public abstract class Impostos
    {
        /// <summary>
        /// Calcula o valor do imposto
        /// </summary>
        public virtual double Valor() => this.CalculaBase() * this.VerificaAliquota();

        /// <summary>
        /// Calcula o valor base do valor do imposto
        /// </summary>
        public abstract double CalculaBase();

        /// <summary>
        /// Verifica a aliquota do valor do imposto
        /// </summary>
        public abstract double VerificaAliquota();
    }
}
