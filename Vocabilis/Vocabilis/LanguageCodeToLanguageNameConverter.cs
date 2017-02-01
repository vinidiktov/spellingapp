using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Vocabilis
{
	public class LanguageCodeToLanguageNameConverter : IValueConverter
	{
		static Dictionary<string, string> languageDict = new Dictionary<string, string> ();

		public LanguageCodeToLanguageNameConverter ()
		{
			string [,] languages =  new string[,] {
				{"abk", "Abkhazian", "Абхазский"},
				{"alb", "Albanian", "Албанский"},
				{"chu", "Church Slavic", "Церковнославянский"},
				{"amh", "Amharic", "Амхарский"},
				{"ara", "Arabic", "Арабский"},
				{"arm", "Armenian", "Армянский"},
				{"aze", "Azerbaijani", "Азербайджанский"},
				{"ave", "Avestan", "Авестийский"},
				{"ava", "Avaric", "Аварский"},
				{"aym", "Aymara", "Аймара"},
				{"bam", "Bambara", "Бамбара"},
				{"bak", "Bashkir", "Башкирский"},
				{"baq", "Basque", "Баскский"},
				{"ben", "Bengali", "Бенгали"},
				{"bos", "Bosnian", "Боснийский"},
				{"bre", "Breton", "Бретонский"},
				{"bul", "Bulgarian", "Болгарский"},
				{"bur", "Burmese", "Бирманский"},
				{"bua", "Buriat", "Бурятский"},
				{"chi", "Chinese", "Китайский"},
				{"cre", "Cree", "Кри"},
				{"dan", "Danish", "Датский"},
				{"deu", "German", "Немецкий"},
				{"eng", "English", "Английский"},
				{"epo", "Esperanto", "Эсперанто"},
				{"est", "Estonian", "Эстонский"},
				{"ewe", "Ewe", "Эве"},
				{"fao", "Faroese", "Фарерский"},
				{"fij", "Fijian", "Фиджи"},
				{"fin", "Finnish", "Финский"},
				{"fra", "French", "Французский"},
				{"fry", "Western Frisian", "Фризский"},
				{"gla", "Gaelic", "Шотландский"},
				{"kat", "Georgian", "Грузинский"},
				{"gre", "Greek", "Греческий"},
				{"grn", "Guarani", "Гварани"},
				{"guj", "Gujarati", "Гуджарати"},
				{"hat", "Haitian", "Гаитянский"},
				{"hau", "Hausa", "Хауса"},
				{"heb", "Hebrew", "Иврит"},
				{"her", "Herero", "Гереро"},
				{"hin", "Hindi", "Хинди"},
				{"ibo", "Igbo", "Ибо"},
				{"ido", "Ido", "Идо"},
				{"ind", "Indonesian", "Индонезийский"},
				{"ina", "Interlingua", "Интерлингва"},
				{"ile", "Interlingue", "Окциденталь"},
				{"iku", "Inuktitut", "Инуктитут"},
				{"ipa", "IPA Transcription", "Транскрипция"},
				{"gle", "Irish", "Ирландский"},
				{"zul", "Zulu", "Зулу"},
				{"isl", "Icelandic", "Исландский"},
				{"ita", "Italian", "Итальянский"},
				{"jpn", "Japanese", "Японский"},
				{"jav", "Javanese", "Яванский"},
				{"yid", "Yiddish", "Идиш"},
				{"kal", "Kalaallisut; Greenlandic", "Гренландский/Эскимосский"},
				{"kan", "Kannada", "Каннада"},
				{"kau", "Kanuri", "Канури"},
				{"kaz", "Kazakh", "Казахский"},
				{"kas", "Kashmiri", "Кашмири"},
				{"cat", "Catalan; Valencian", "Каталанский"},
				{"khm", "Central Khmer", "Кхмер"},
				{"kir", "Kirghiz", "Киргизский"},
				{"run", "Rundi", "Курунди/Рунди"},
				{"kom", "Komi", "Коми"},
				{"kor", "Korean", "Корейский"},
				{"cos", "Corsican", "Корсиканский"},
				{"hrv", "Croatian", "Хорватский"},
				{"kur", "Kurdish", "Курдский"},
				{"lao", "Lao", "Лаосский"},
				{"lat", "Latin", "Латинский"},
				{"lav", "Latvian", "Латышский"},
				{"lin", "Lingala", "Лингала (нгала)"},
				{"lit", "Lithuanian", "Литовский"},
				{"ltz", "Luxembourgish", "Люксембургский"},
				{"mlg", "Malagasy", "Малагасийский (Мадагаскарский)"},
				{"msa", "Malay", "Малайский"},
				{"mal", "Malayalam", "Малаялам"},
				{"mlt", "Maltese", "Мальтийский"},
				{"glv", "Manx", "Мэнский"},
				{"mri", "Maori", "Маори"},
				{"mar", "Marathi", "Маратхи"},
				{"mkd", "Macedonian", "Македонский"},
				{"mol", "Moldavian", "Молдавский"},
				{"mon", "Mongolian", "Монгольский"},
				{"nau", "Nauru", "Науру"},
				{"nav", "Navajo; Navaho", "Навахо"},
				{"nep", "Nepali", "Непальский"},
				{"nld", "Dutch; Flemish", "Нидерландский"},
				{"nor", "Norwegian", "Норвежский"},
				{"ori", "Oriya", "Ория"},
				{"oss", "Ossetian; Ossetic", "Осетинский"},
				{"fas", "Persian", "Персидский (Фарси)"},
				{"pol", "Polish", "Польский"},
				{"por", "Portuguese", "Португальский"},
				{"pan", "Panjabi; Punjabi", "Панджаби (Пенджабский)"},
				{"que", "Quechua", "Кечуа"},
				{"roh", "Romansh", "Ретороманский"},
				{"ron", "Romanian", "Румынский"},
				{"rus", "Russian", "Русский"},
				{"sag", "Sango", "Санго"},
				{"san", "Sanskrit", "Санскрит"},
				{"srd", "Sardinian", "Сардинский"},
				{"swe", "Swedish", "Шведский"},
				{"srp", "Serbian", "Сербский"},
				{"slk", "Slovak", "Словацкий"},
				{"slv", "Slovenian", "Словенский"},
				{"som", "Somali", "Сомали"},
				{"spa", "Spanish", "Испанский"},
				{"swa", "Swahili", "Суахили"},
				{"tgk", "Tajik", "Таджикский"},
				{"tat", "Tatar", "Татарский"},
				{"tel", "Telugu", "Телугу"},
				{"tha", "Thai", "Таиландский"},
				{"tib", "Tibetan", "Тибетский"},
				{"tir", "Tigrinya", "Тигринья"},
				{"ces", "Czech", "Чешский"},
				{"che", "Chechen", "Чеченский"},
				{"chv", "Chuvash", "Чувашский"},
				{"tur", "Turkish", "Турецкий"},
				{"tuk", "Turkmen", "Туркменский"},
				{"uig", "Uighur; Uyghur", "Уйгурский"},
				{"ukr", "Ukrainian", "Украинский"},
				{"hun", "Hungarian", "Венгерский (Мадьярский)"},
				{"urd", "Urdu", "Урду"},
				{"uzb", "Uzbek", "Узбекский"},
				{"vie", "Vietnamese", "Вьетнамский"},
				{"wel", "Welsh", "Валлийский (Уэльский)"},
				{"wln", "Walloon", "Валлонский"},
				{"bel", "Belarusian", "Белорусский"},
				{"wol", "Wolof", "Волоф"},
				{"yor", "Yoruba", "Йоруба"},
				{"sah", "Yakut", "Якутский"},
				{"ckt", "Chuukese", "Чукотский"}
			};

			var upperBound = languages.GetUpperBound (0);

			for (var i = 0; i < languages.GetUpperBound(0); ++i)
			{
				languageDict [languages [i, 0]] = languages [i, 2];
			}

//			foreach (var language in languages)
//			{
//				languageDict [language [0]] = language [2];
//			}
		}

		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{

			if (value is string)  {

				return languageDict [(string)value];
			}
			return value;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

