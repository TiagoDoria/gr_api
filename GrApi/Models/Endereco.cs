namespace GrApi.Models
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Localidade { get; set; }
        public string Estado { get; set; }
        public string Uf { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
    }
}


/*
 "cep": "01001-000",
      "logradouro": "Praça da Sé",
      "complemento": "lado ímpar",
      "unidade": "",
      "localidade": "Sé",
      "localidade": "São Paulo",
      "uf": "SP",
      "estado": "São Paulo",
      "regiao": "Sudeste",
      "ibge": "3550308",
      "gia": "1004",
      "ddd": "11",
      "siafi": "7107"
 */