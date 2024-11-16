namespace myfinance_web_dotnet.Domain
{
    public class Transacao
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public string Historico { get; set; }

        public string Tipo { get; set; }

        public int PlanocontaId  { get; set; }

        public PlanoConta PlanoConta { get; set; }
    }
}