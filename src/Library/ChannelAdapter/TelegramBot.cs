using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot;
using Library;

//telegram tenga los tres metodos del adaptador
//metodos aparte si hay preciso mensajes
//O usar este codigo y modificarlo para q la logica cumpla los metodos del adapter

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
        /// *Importante*:
        /// Para probar este ejemplo, crea un bot nuevo y reemplaza este 
        /// token por el de tu bot.
        /// </summary>
        private static string Token = "1073884003:AAFJ4GZVartXwX3pBnd16HhS3bYKlANqcZk";

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
        
            Console.WriteLine("Bot is up!.");

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
        private static async Task HandleMessageReceived (Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");
            
            SingleInstance<TelegramBot>.GetInstance.ReadUserInput(message.Chat.Id, message.Text.ToLower());
        }

        /// <summary>
        /// Envía una imágen como respuesta al mensaje recibido.
        /// Como ejemplo enviamos siempre la misma foto.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task SendProfileImage(Message message)
        {
            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

            const string filePath = @"profile.jpeg";
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
            await Bot.SendPhotoAsync(
                chatId: message.Chat.Id,
                photo: new InputOnlineFile(fileStream, fileName),
                caption: "Te ves bien!"
            );
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

        public void SendTextToUser(long ID, string response)
        {  
            Bot.SendTextMessageAsync(ID, response);
        }

        public void ReadUserInput(long ID, string input)
        {
            Database db = SingleInstance<DatabaseMap>.GetInstance.GetDatabaseInstance(ID);

            db.SetAdapter(this);
            
            if (db.State == Status.Init)
            {
                this.SendTextToUser(ID, "Bienvenid@! Mi nombre es Pepe, estoy aquí para ayudarte a encontrar la casa de tus sueños." + Environment.NewLine + "Por favor, ingresa 1 para buscar una propiedad en alquiler o 2 para buscar una propiedad a la venta.");

                db.SetState(Status.WaitingTransactionType);
            }

            else
            {
                SingleInstance<SimpleInterpreter>.GetInstance.ParseInput(input, db);
            }
        }
    }
}