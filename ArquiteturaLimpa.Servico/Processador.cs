using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArquiteturaLimpa.Servico
{
    public class Processador : IHostedService, IDisposable
    {
        private readonly ILogger<Processador> _logger;
        private readonly IConfiguration _configuration;
        private Timer _timer;

        public Processador(ILogger<Processador> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void IniciarMotor(object state)
        {
            _logger.LogInformation("Rotina executada");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço iniciado.");

            var intervalo = _configuration.GetValue<int>("Intervalo");

            _timer = new Timer(IniciarMotor, null, TimeSpan.Zero, TimeSpan.FromSeconds(intervalo));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Serviço parado.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}