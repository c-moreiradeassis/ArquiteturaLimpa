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
        private Timer _timer;

        public Processador(ILogger<Processador> logger)
        {
            _logger = logger;
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
            _logger.LogInformation("Time Hosted service is running.");

            _timer = new Timer(IniciarMotor, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Time Hosted service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }


    }
}