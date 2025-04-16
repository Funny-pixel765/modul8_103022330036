using System.Numerics;

BankTransferConfigApp configApp = new BankTransferConfigApp();
    
    Console.WriteLine("Welcome to Bank Transfer App");
    Console.WriteLine("Please select the language (en/id):");
    int bhs = 0;
    string input = Console.ReadLine();
    if (input == "en")
    {
        bhs = 1;
    }
    else if (input == "id")
    {
        bhs = 2;
    }
    else
    {
        Console.WriteLine("Invalid language selection. Defaulting to English.");
        bhs = 1;
    }
    configApp.ReadConfigFile();
    if (bhs == 1)
    {
        configApp.config.lang = "en";
    }
    else if (bhs == 2)
    {
        configApp.config.lang = "id";
    }
    string lang = configApp.config.lang;

    if (lang == "en")
    {
    Console.WriteLine("Please insert the amount of money to transfer :");
    }
    else if (lang == "id")
    {
    Console.WriteLine("Masukan jumlah uang yang akan ditransfer :");
    }


    int nominal_transfer = int.Parse(Console.ReadLine()); 

    int biaya_transfer =

    (nominal_transfer > configApp.config.transfer.threshold)
    ? configApp.config.transfer.high_fee
    : configApp.config.transfer.low_fee;

      if (lang == "en")
          {
             Console.WriteLine($"Transfer fee = {biaya_transfer}");
             Console.WriteLine($"Total amount = {nominal_transfer + biaya_transfer}");
             Console.WriteLine("\nSelect transfer method:");
         }

        else if (lang == "id")
        {
            Console.WriteLine($"Biaya transfer = {biaya_transfer}");
            Console.WriteLine($"Total biaya = {nominal_transfer + biaya_transfer}");
            Console.WriteLine("\nPilih metode transfer:");
        }

        for (int i = 0; i < configApp.config.methods.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + configApp.config.methods[i]);
            }
        Console.ReadLine();

        Console.WriteLine();
            if (lang == "en")
            {
                Console.WriteLine($"Please type {configApp.config.confirmation.en} to confirm the transaction : ");
            }

            else if (lang == "id")
            {
                  Console.WriteLine($"Ketik {configApp.config.confirmation.id} untuk konfirmasi transaksi :");
            }


        string konfirmasi = Console.ReadLine();

            if (lang == "en")
                {
                      Console.WriteLine(
                      (konfirmasi == configApp.config.confirmation.en)
                         ? "The transfer is completed!"
                        : "Transfer is cancelled!");
                        }

            else if (lang == "id")
                {
                      Console.WriteLine(
                        (konfirmasi == configApp.config.confirmation.id)
                    ? "Proses transfer berhasil!"
            :         "Transfer dibatalkan!"
            );
}