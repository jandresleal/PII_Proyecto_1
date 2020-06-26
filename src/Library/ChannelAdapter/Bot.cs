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
    public class T 
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
        public void StartBot()
        {
            Bot = new TelegramBotClient(Token);
            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en _background_).
            Bot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );

            Console.WriteLine("Bot is Up!");
            Console.WriteLine($"Bienvenid@! Soy Pepe, ¿Estas buscando una propiedad para alquilar o comprar? Yo te ayudaré en eso!! {Environment.NewLine} Escribe 1 si desea alquilar o 2 si desea comprar.");
            

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();

            // Terminamos el bot.
            cts.Cancel();
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
        private static async Task HandleMessageReceived(Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");
            
            string response;

            string lastResponse = string.Empty;

            //Cambiar para lista de posibles respuestas

            if (lastResponse == "Por favor, dime el precio mínimo")
            {
                int number;

                bool isParseable = Int32.TryParse(message.Text.ToLower(), out number);

                response = "Por favor, escribe el barrio";
                lastResponse = response;
            }
            
            switch(message.Text.ToLower())
            {
                // alquilar propiedad
                case "1":
                    // SimpleInterpreter.GetInstance.ParseInput("alquilar, alquilar", Database db);
                    response = "Por favor, dime el precio mínimo";
                    lastResponse = response;
                    break;
                
                // comprar propiedad
                case "2":
                    // SimpleInterpreter.GetInstance.ParseInput("comprar, comprar", Database db);
                    response = "Por favor, dime el precio máximo";
                    lastResponse = response;
                    break;

                case "chau": 
                    //adapter.UserInput("chau");
                    response = "Chau! Que andes bien!";
                    //response = adapter.SendTextToUser(text);
                    break;

                case "foto":
                    // si nos piden una foto, mandamos la foto en vez de responder
                    // con un mensaje de texto.
                    await SendProfileImage(message);
                    return;

                default: 
                    response = "Disculpa, no se qué hacer con ese mensaje!";
                    break;
            }

            // enviamos el texto de respuesta
            await Bot.SendTextMessageAsync(message.Chat.Id, response);
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
    }
}