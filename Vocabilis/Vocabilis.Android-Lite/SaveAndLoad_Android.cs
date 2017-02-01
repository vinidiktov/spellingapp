using System;
using Xamarin.Forms;
using System.IO;
using Vocabilis.Droid;
using System.Threading.Tasks;

[assembly: Dependency (typeof (SaveAndLoad))]
namespace Vocabilis.Droid
{
	public class SaveAndLoad : ISaveAndLoad {
		public void SaveText (string filename, string text) {
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, filename);
			System.IO.File.WriteAllText (filePath, text);
		}
		public async Task<string> LoadText (string filename) {
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, filename);
			return System.IO.File.ReadAllText (filePath);
		}
	}
}

