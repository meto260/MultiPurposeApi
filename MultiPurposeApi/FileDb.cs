using Newtonsoft.Json;
using System.Text;

namespace MultiPurposeApi {
    public class FileDb {
        string filename;
        public FileDb(string filename) {
            Directory.CreateDirectory("data");
            this.filename = Path.Combine(Environment.CurrentDirectory, "data", filename);
        }
        public List<Dictionary<string, string>> Get() {
            try {
                var source = File.ReadAllLines(filename);
                var result = new List<Dictionary<string, string>>();
                foreach (string line in source) {
                    result.Add(JsonConvert.DeserializeObject<Dictionary<string, string>>(line));
                }
                return result;
            }
            catch { return default; }
        }
        public bool Add(object obj) {
            try {
                var deserialized = JsonConvert.DeserializeObject(obj.ToString());
                var addobj = JsonConvert.SerializeObject(deserialized);
                try {
                    var source = File.ReadAllLines(filename);
                    if (!source.Contains(addobj)) {
                        File.AppendAllLines(filename, new List<string> { addobj });
                        return true;
                    }
                }
                catch {
                    File.AppendAllLines(filename, new List<string> { addobj });
                    return true;
                }
            }
            catch {  }
            return false;
        }
    }
}
