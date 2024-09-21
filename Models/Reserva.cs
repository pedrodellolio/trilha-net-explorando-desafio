namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        private readonly int MinDiasReservadosParaDesconto = 10;
        private readonly decimal Desconto = 0.1M;

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool possuiEspaco = Suite.Capacidade >= hospedes.Count;
            if (possuiEspaco)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("O número de hóspedes é maior que a capacidade da suite.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            bool possuiDesconto = DiasReservados >= MinDiasReservadosParaDesconto;
            if (possuiDesconto)
            {
                valor *= 1 - Desconto;
            }

            return valor;
        }
    }
}