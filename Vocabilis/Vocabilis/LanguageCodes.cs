using System;
using System.Collections.Generic;

namespace Vocabilis.Scheduler
{
	public static class LanguageCodes
	{
		public static Dictionary<string, string> Languages { get; }

		static LanguageCodes ()
		{
			Languages = SetLanguageCodes ();
		}

		public static string GetLanguageNameForCode(string code)
		{
			return Languages [code];
		}

		static Dictionary<string, string> SetLanguageCodes ()
		{

			Dictionary<string, string> languages = new Dictionary<string, string>()
			{
				{"abk", "Abkhazian"},
				{"alb", "Albanian"},
				{"chu", "Church Slavic"},
				{"amh", "Amharic"},
				{"ara", "Arabic"},
				{"arm", "Armenian"},
				{"aze", "Azerbaijani"},
				{"ave", "Avestan"},
				{"ava", "Avaric"},
				{"aym", "Aymara"},
				{"bam", "Bambara"},
				{"bak", "Bashkir"},
				{"baq", "Basque"},
				{"ben", "Bengali"},
				{"bos", "Bosnian"},
				{"bre", "Breton"},
				{"bul", "Bulgarian"},
				{"bur", "Burmese"},
				{"bua", "Buriat"},
				{"chi", "Chinese"},
				{"cre", "Cree"},
				{"dan", "Danish"},
				{"deu", "German"},
				{"eng", "English"},
				{"epo", "Esperanto"},
				{"est", "Estonian"},
				{"ewe", "Ewe"},
				{"fao", "Faroese"},
				{"fij", "Fijian"},
				{"fin", "Finnish"},
				{"fra", "French"},
				{"fry", "Western Frisian"},
				{"gla", "Gaelic"},
				{"kat", "Georgian"},
				{"gre", "Greek"},
				{"grn", "Guarani"},
				{"guj", "Gujarati"},
				{"hat", "Haitian"},
				{"hau", "Hausa"},
				{"heb", "Hebrew"},
				{"her", "Herero"},
				{"hin", "Hindi"},
				{"ibo", "Igbo"},
				{"ido", "Ido"},
				{"ind", "Indonesian"},
				{"ina", "Interlingua"},
				{"ile", "Interlingue"},
				{"iku", "Inuktitut"},
				{"ipa", "IPA Transcription"},
				{"gle", "Irish"},
				{"zul", "Zulu"},
				{"isl", "Icelandic"},
				{"ita", "Italian"},
				{"jpn", "Japanese"},
				{"jav", "Javanese"},
				{"yid", "Yiddish"},
				{"kal", "Kalaallisut; Greenlandic"},
				{"kan", "Kannada"},
				{"kau", "Kanuri"},
				{"kaz", "Kazakh"},
				{"kas", "Kashmiri"},
				{"cat", "Catalan; Valencian"},
				{"khm", "Central Khmer"},
				{"kir", "Kirghiz"},
				{"run", "Rundi"},
				{"kom", "Komi"},
				{"kor", "Korean"},
				{"cos", "Corsican"},
				{"hrv", "Croatian"},
				{"kur", "Kurdish"},
				{"lao", "Lao"},
				{"lat", "Latin"},
				{"lav", "Latvian"},
				{"lin", "Lingala"},
				{"lit", "Lithuanian"},
				{"ltz", "Luxembourgish"},
				{"mlg", "Malagasy"},
				{"msa", "Malay"},
				{"mal", "Malayalam"},
				{"mlt", "Maltese"},
				{"glv", "Manx"},
				{"mri", "Maori"},
				{"mar", "Marathi"},
				{"mkd", "Macedonian"},
				{"mol", "Moldavian"},
				{"mon", "Mongolian"},
				{"nau", "Nauru"},
				{"nav", "Navajo; Navaho"},
				{"nep", "Nepali"},
				{"nld", "Dutch; Flemish"},
				{"nor", "Norwegian"},
				{"ori", "Oriya"},
				{"oss", "Ossetian; Ossetic"},
				{"fas", "Persian"},
				{"pol", "Polish"},
				{"por", "Portuguese"},
				{"pan", "Panjabi; Punjabi"},
				{"que", "Quechua"},
				{"roh", "Romansh"},
				{"ron", "Romanian"},
				{"rus", "Russian"},
				{"sag", "Sango"},
				{"san", "Sanskrit"},
				{"srd", "Sardinian"},
				{"swe", "Swedish"},
				{"srp", "Serbian"},
				{"slk", "Slovak"},
				{"slv", "Slovenian"},
				{"som", "Somali"},
				{"spa", "Spanish"},
				{"swa", "Swahili"},
				{"tgk", "Tajik"},
				{"tat", "Tatar"},
				{"tel", "Telugu"},
				{"tha", "Thai"},
				{"tib", "Tibetan"},
				{"tir", "Tigrinya"},
				{"ces", "Czech"},
				{"che", "Chechen"},
				{"chv", "Chuvash"},
				{"tur", "Turkish"},
				{"tuk", "Turkmen"},
				{"uig", "Uighur; Uyghur"},
				{"ukr", "Ukrainian"},
				{"hun", "Hungarian"},
				{"urd", "Urdu"},
				{"uzb", "Uzbek"},
				{"vie", "Vietnamese"},
				{"wel", "Welsh"},
				{"wln", "Walloon"},
				{"bel", "Belarusian"},
				{"wol", "Wolof"},
				{"yor", "Yoruba"},
				{"sah", "Yakut"},
				{"ckt", "Chuukese"}
			};

			return languages;

		}
	}
}

//#include "LanguageCodes.h"
//#include <vector>
//#include <string>  
//#include <map>
//
//using namespace std;
////--------------------------------------------------------------------------
//LanguageCodes::LanguageCodes(a_locale Locale)
//	: m_locale(Locale), LANGUAGE_CODE(0)
//{
//	const wstring s[][3] =  {
//		{L"abk", L"Abkhazian", L"Абхазский"},
//		{L"alb", L"Albanian", L"Албанский"},
//		{L"chu", L"Church Slavic", L"Церковнославянский"},
//		{L"amh", L"Amharic", L"Амхарский"},
//		{L"ara", L"Arabic", L"Арабский"},
//		{L"arm", L"Armenian", L"Армянский"},
//		{L"aze", L"Azerbaijani", L"Азербайджанский"},
//		{L"ave", L"Avestan", L"Авестийский"},
//		{L"ava", L"Avaric", L"Аварский"},
//		{L"aym", L"Aymara", L"Аймара"},
//		{L"bam", L"Bambara", L"Бамбара"},
//		{L"bak", L"Bashkir", L"Башкирский"},
//		{L"baq", L"Basque", L"Баскский"},
//		{L"ben", L"Bengali", L"Бенгали"},
//		{L"bos", L"Bosnian", L"Боснийский"},
//		{L"bre", L"Breton", L"Бретонский"},
//		{L"bul", L"Bulgarian", L"Болгарский"},
//		{L"bur", L"Burmese", L"Бирманский"},
//		{L"bua", L"Buriat", L"Бурятский"},
//		{L"chi", L"Chinese", L"Китайский"},
//		{L"cre", L"Cree", L"Кри"},
//		{L"dan", L"Danish", L"Датский"},
//		{L"deu", L"German", L"Немецкий"},
//		{L"eng", L"English", L"Английский"},
//		{L"epo", L"Esperanto", L"Эсперанто"},
//		{L"est", L"Estonian", L"Эстонский"},
//		{L"ewe", L"Ewe", L"Эве"},
//		{L"fao", L"Faroese", L"Фарерский"},
//		{L"fij", L"Fijian", L"Фиджи"},
//		{L"fin", L"Finnish", L"Финский"},
//		{L"fra", L"French", L"Французский"},
//		{L"fry", L"Western Frisian", L"Фризский"},
//		{L"gla", L"Gaelic", L"Шотландский"},
//		{L"kat", L"Georgian", L"Грузинский"},
//		{L"gre", L"Greek", L"Греческий"},
//		{L"grn", L"Guarani", L"Гварани"},
//		{L"guj", L"Gujarati", L"Гуджарати"},
//		{L"hat", L"Haitian", L"Гаитянский"},
//		{L"hau", L"Hausa", L"Хауса"},
//		{L"heb", L"Hebrew", L"Иврит"},
//		{L"her", L"Herero", L"Гереро"},
//		{L"hin", L"Hindi", L"Хинди"},
//		{L"ibo", L"Igbo", L"Ибо"},
//		{L"ido", L"Ido", L"Идо"},
//		{L"ind", L"Indonesian", L"Индонезийский"},
//		{L"ina", L"Interlingua", L"Интерлингва"},
//		{L"ile", L"Interlingue", L"Окциденталь"},
//		{L"iku", L"Inuktitut", L"Инуктитут"},
//		{L"ipa", L"IPA Transcription", L"Транскрипция"},
//		{L"gle", L"Irish", L"Ирландский"},
//		{L"zul", L"Zulu", L"Зулу"},
//		{L"isl", L"Icelandic", L"Исландский"},
//		{L"ita", L"Italian", L"Итальянский"},
//		{L"jpn", L"Japanese", L"Японский"},
//		{L"jav", L"Javanese", L"Яванский"},
//		{L"yid", L"Yiddish", L"Идиш"},
//		{L"kal", L"Kalaallisut; Greenlandic", L"Гренландский/Эскимосский"},
//		{L"kan", L"Kannada", L"Каннада"},
//		{L"kau", L"Kanuri", L"Канури"},
//		{L"kaz", L"Kazakh", L"Казахский"},
//		{L"kas", L"Kashmiri", L"Кашмири"},
//		{L"cat", L"Catalan; Valencian", L"Каталанский"},
//		{L"khm", L"Central Khmer", L"Кхмер"},
//		{L"kir", L"Kirghiz", L"Киргизский"},
//		{L"run", L"Rundi", L"Курунди/Рунди"},
//		{L"kom", L"Komi", L"Коми"},
//		{L"kor", L"Korean", L"Корейский"},
//		{L"cos", L"Corsican", L"Корсиканский"},
//		{L"hrv", L"Croatian", L"Хорватский"},
//		{L"kur", L"Kurdish", L"Курдский"},
//		{L"lao", L"Lao", L"Лаосский"},
//		{L"lat", L"Latin", L"Латинский"},
//		{L"lav", L"Latvian", L"Латышский"},
//		{L"lin", L"Lingala", L"Лингала (нгала)"},
//		{L"lit", L"Lithuanian", L"Литовский"},
//		{L"ltz", L"Luxembourgish", L"Люксембургский"},
//		{L"mlg", L"Malagasy", L"Малагасийский (Мадагаскарский)"},
//		{L"msa", L"Malay", L"Малайский"},
//		{L"mal", L"Malayalam", L"Малаялам"},
//		{L"mlt", L"Maltese", L"Мальтийский"},
//		{L"glv", L"Manx", L"Мэнский"},
//		{L"mri", L"Maori", L"Маори"},
//		{L"mar", L"Marathi", L"Маратхи"},
//		{L"mkd", L"Macedonian", L"Македонский"},
//		{L"mol", L"Moldavian", L"Молдавский"},
//		{L"mon", L"Mongolian", L"Монгольский"},
//		{L"nau", L"Nauru", L"Науру"},
//		{L"nav", L"Navajo; Navaho", L"Навахо"},
//		{L"nep", L"Nepali", L"Непальский"},
//		{L"nld", L"Dutch; Flemish", L"Нидерландский"},
//		{L"nor", L"Norwegian", L"Норвежский"},
//		{L"ori", L"Oriya", L"Ория"},
//		{L"oss", L"Ossetian; Ossetic", L"Осетинский"},
//		{L"fas", L"Persian", L"Персидский (Фарси)"},
//		{L"pol", L"Polish", L"Польский"},
//		{L"por", L"Portuguese", L"Португальский"},
//		{L"pan", L"Panjabi; Punjabi", L"Панджаби (Пенджабский)"},
//		{L"que", L"Quechua", L"Кечуа"},
//		{L"roh", L"Romansh", L"Ретороманский"},
//		{L"ron", L"Romanian", L"Румынский"},
//		{L"rus", L"Russian", L"Русский"},
//		{L"sag", L"Sango", L"Санго"},
//		{L"san", L"Sanskrit", L"Санскрит"},
//		{L"srd", L"Sardinian", L"Сардинский"},
//		{L"swe", L"Swedish", L"Шведский"},
//		{L"srp", L"Serbian", L"Сербский"},
//		{L"slk", L"Slovak", L"Словацкий"},
//		{L"slv", L"Slovenian", L"Словенский"},
//		{L"som", L"Somali", L"Сомали"},
//		{L"spa", L"Spanish", L"Испанский"},
//		{L"swa", L"Swahili", L"Суахили"},
//		{L"tgk", L"Tajik", L"Таджикский"},
//		{L"tat", L"Tatar", L"Татарский"},
//		{L"tel", L"Telugu", L"Телугу"},
//		{L"tha", L"Thai", L"Таиландский"},
//		{L"tib", L"Tibetan", L"Тибетский"},
//		{L"tir", L"Tigrinya", L"Тигринья"},
//		{L"ces", L"Czech", L"Чешский"},
//		{L"che", L"Chechen", L"Чеченский"},
//		{L"chv", L"Chuvash", L"Чувашский"},
//		{L"tur", L"Turkish", L"Турецкий"},
//		{L"tuk", L"Turkmen", L"Туркменский"},
//		{L"uig", L"Uighur; Uyghur", L"Уйгурский"},
//		{L"ukr", L"Ukrainian", L"Украинский"},
//		{L"hun", L"Hungarian", L"Венгерский (Мадьярский)"},
//		{L"urd", L"Urdu", L"Урду"},
//		{L"uzb", L"Uzbek", L"Узбекский"},
//		{L"vie", L"Vietnamese", L"Вьетнамский"},
//		{L"wel", L"Welsh", L"Валлийский (Уэльский)"},
//		{L"wln", L"Walloon", L"Валлонский"},
//		{L"bel", L"Belarusian", L"Белорусский"},
//		{L"wol", L"Wolof", L"Волоф"},
//		{L"yor", L"Yoruba", L"Йоруба"},
//		{L"sah", L"Yakut", L"Якутский"},
//		{L"ckt", L"Chuukese", L"Чукотский"}
//	};
//	vector <wstring> language;
//	size_t arraysize = sizeof s / sizeof s[0];
//
//	for (size_t i = 0; i < arraysize; ++i )
//	{
//		language.clear();
//		language.push_back(s[i][LANGUAGE_CODE]);
//		language.push_back(s[i][ENGLISH_LOCALE]);
//		language.push_back(s[i][RUSSIAN_LOCALE]);
//		language_matrix.push_back(language);
//	}
//
//	//lbl1->Caption = langmatrix[2][LANGUAGE_RUSSIAN].c_str();
//	//s[0][2].c_str();
//
//	map<const wstring, wstring> m1;
//	m1[L"ita"] = L"Итальянский";
//	m1[L"fre"] = L"Французский";
//	//lbl2->Caption = m1[L"fre"].c_str();
//
//	map<const wstring,wstring> m2;
//	map<const wstring,wstring>::iterator iter;
//	for (iter= m1.begin(); iter != m1.end();  iter++)
//	{
//		m2[iter->second] = iter->first;
//	}
//	//lbl3->Caption = m2[L"Французский"].c_str();
//
//	//    wstring GetLanguage(language_code);
//	//    wstring GetLanguageCode(language_as_string);
//	//    vector<wstring> GetLanguageList();
//
//	//cbb1->Items->Add(L"Пункт первый");
//	//cbb1->Items->Add(L"Пункт второй");
//	//cbb1->ItemIndex = cbb1->Items->IndexOf(L"Пункт второй");
//
//}
////--------------------------------------------------------------------------
//wstring LanguageCodes::GetLanguage(const wstring &language_code)
//{
//	for (size_t i = 0; i < language_matrix.size(); ++i)
//	{
//		if (language_matrix[i][LANGUAGE_CODE] == language_code)
//		{
//			return language_matrix[i][m_locale];
//		}
//	}
//	return language_code;
//}
////--------------------------------------------------------------------------
//std::wstring LanguageCodes::GetLanguageCode(const std::wstring &language)
//{
//	for (size_t i = 0; i < language_matrix.size(); ++i)
//	{
//		if (language_matrix[i][m_locale] == language)
//		{
//			return language_matrix[i][LANGUAGE_CODE];
//		}
//	}
//	return language;
//}
////--------------------------------------------------------------------------
//wstring LanguageCodes::GetLanguage(int item_index)
//{
//	return L"undefined";
//}
////--------------------------------------------------------------------------
//int LanguageCodes::GetLanguageIndex(const wstring &language_code)
//{
//	return -1;
//}
////--------------------------------------------------------------------------
//int LanguageCodes::GetLanguageCodeIndex(const std::wstring &language)
//{
//	for (size_t i = 0; i < language_matrix.size(); ++i)
//	{
//		if (language_matrix[i][LANGUAGE_CODE] == language)
//		{
//			return i;
//		}
//	}
//	return -1;
//}
////--------------------------------------------------------------------------
//vector<wstring> LanguageCodes::GetLanguageList(void)
//{
//	vector<wstring> result;
//	for (size_t i = 0; i < language_matrix.size(); ++i)
//	{
//		result.push_back(language_matrix[i][m_locale]);
//	}
//
//	return result;
//}
////--------------------------------------------------------------------------
//void LanguageCodes::SetLocale(a_locale Locale)
//{
//	m_locale = Locale;
//}
////--------------------------------------------------------------------------
//a_locale LanguageCodes::GetLocale()
//{
//	return m_locale;
//}
////--------------------------------------------------------------------------

