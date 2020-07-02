using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;


namespace Library
{
    public class TelegramBot : IChannelAdapter
    {
        /// <summary>
        /// La instancia del bot.
        /// </summary>
        private static TelegramBotClient Bot;

        /// <summary>
        /// El token provisto por Telegram al crear el bot.
        ///
        /// </summary>
        private static string Token = "1031693629:AAFxdWGZ4miRKnlCjCSZyIDj5KBrE11kwKk";

        /// <summary>
        /// Punto de entrada.
        /// </summary>
        public void Run()
        {
            Bot = new TelegramBotClient(Token);
            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en _background_).
            Bot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );
        
            Console.WriteLine("Bot is up!");

            Console.ReadLine();
        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo
        /// mensajes, ediciones de mensajes, respuestas a botones, etc. En este
        /// ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try 
            {
                // sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(update.Message);
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        
        // no supimos solucionar el warning sin romper el programa
        private static async Task HandleMessageReceived (Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");
            
            SingleInstance<TelegramBot>.GetInstance.ReadUserInput(message.Chat.Id, message.Text.ToLower());
        }

        /// <summary>
        /// Manejo de excepciones. 
        /// Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        public void SendTextToUser(long id, string response)
        {
            Bot.SendTextMessageAsync(new ChatId(id), response);
        }

        public void ReadUserInput(long id, string input)
        {
            SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(id);

            SingleInstance<Mediator>.GetInstance.SetAdapter(id, this);

            SingleInstance<Mediator>.GetInstance.ToInterpreter(id, input);
        }
    }
}