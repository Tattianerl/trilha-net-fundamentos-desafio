namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        List<Veiculo> veiculos = new List<Veiculo>();
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            Console.WriteLine("Digite o modelo do veículo:");
            string modelo = Console.ReadLine();

            if (!string.IsNullOrEmpty(placa) && !string.IsNullOrEmpty(modelo))
            {
                Veiculo veiculo = new Veiculo(placa.ToUpper(), modelo.ToUpper());
                veiculos.Add(veiculo);
                Console.WriteLine("Veículo cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Preencha todos os dados. Tente novamente.");
            }
        }

        
           public void RemoverVeiculo()
          {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe na lista 
            var veiculoEncontrado = veiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());

            if (veiculoEncontrado != null)
            {
                // Remove o veículo da lista
                veiculos.Remove(veiculoEncontrado);

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                string inputHoras = Console.ReadLine();

                if (!int.TryParse(inputHoras, out int horas) || horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Operação cancelada.");
                    return;
                }

                decimal precoInicial = 5;
                decimal precoPorHora = 2;

                // Calcula o valor total
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                Console.WriteLine($"O veículo de placa {veiculoEncontrado.Placa.ToUpper()}, modelo {veiculoEncontrado.Modelo.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                Console.WriteLine("##### Volte Sempre!!! ####");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }


        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");


                foreach (Veiculo veiculo in veiculos)
                {
                    Console.WriteLine($"Placa:{veiculo.Placa}, Modelo:{veiculo.Modelo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
