using System.Text.Json;
using System.Text.Json.Serialization;
using static BankTransferConfig;


public class BankTransferConfig
{   //mendefinisikan class BankTransferConfig dengan memanggil satu2 sesuai keinginan kode json
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public string[] methods { get; set; }
    public Confirmation confirmation { get; set; }
    //membuat class Transfer yang berisi threshold, low_fee, dan high_fee seperti yang ada di json
    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }
    //membuat class Confirmation yang berisi en dan id seperti yang ada di json
    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }
}

//membuat class banktransfer untuk mengetahui config yang ada di json dan membaca kode di json, serta penginputan yang ada
public class BankTransferConfigApp
{
    public BankTransferConfig config;
    private static string file_path = Path.Combine(Directory.GetCurrentDirectory(), "bank_transfer_config.json");

    public void ReadConfigFile() //untuk membaca file json dam config yang ada di dalamnya
    {
        
        string configJsonData = File.ReadAllText(file_path);
        config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
    }

    private void WriteNewConfigFile()
    {
        JsonSerializerOptions option = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(config, option);
        File.WriteAllText(file_path, jsonString);
    }

    private void SetDefault() //untuk meng set default config dan menentukan menu yang harus dipilih
    {
        config = new BankTransferConfig();

        config.lang = "en";
        
        Transfer transfer = new();
        transfer.threshold = 25000000;
        transfer.low_fee = 6500;
        transfer.high_fee = 15000;
        config.transfer = transfer;
        config.methods = new string[] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
        Confirmation confirmation = new();
        confirmation.en = "yes";
        confirmation.id = "ya";
        config.confirmation = confirmation;

    }

    //untuk membaca class yang sudah dibuat dalam

    public BankTransferConfigApp()
    {
        try
        {
            ReadConfigFile();
        }
        catch
        {
            SetDefault();
            WriteNewConfigFile();
        }
    }
}