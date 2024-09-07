using RobotWhatsapp;

var whatsapp = new WhatsappDriver();
//whatsapp.SendMessageText("Mensagem do bot do curso", "RPA - Gabriel");

whatsapp.SendMessageWithImage(
    ":robo Mensagem do bot do curso com imagem",
    "D:\\documentos\\github\\curso_automacao_processos_rpa_dotnet\\imagem_bot\\image-eb6d9a66f67d4f23a7a5494985738918.jpg",
    "RPA - Gabriel");

//whatsapp.SendMessageWithEmoji(
//    "Mensagem do bot do curso com emojis",
//    new List<string> { "robo" },
//    "RPA - Gabriel");
