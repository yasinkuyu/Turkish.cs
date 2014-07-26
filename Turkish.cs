/*
 * @yasinkuyu
 * Date: 24.03.2013
 */

namespace Insya
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;

    public class Turkish
    {

        string VOWELS = "aıoöuüei";
        string FRONT_VOWELS = "aıou";
        string BACK_VOWELS = "eiöü";
        string HARD_CONSONANTS = "fstkçşhp";
        string DISCONTINIOUS_HARD_CONSONANTS = "pçtk";
        string SOFTEN_DHC = "bcdğ";
        string DISCONTINIOUS_HARD_CONSONANTS_AFTER_SUFFIX = "pçk";
        string SOFTEN_DHC_AFTER_SUFFIX = "bcğ";

        Dictionary<string, string> MINOR_HARMONY = new
        Dictionary<string, string>()
        { 
            { "a", "ı" },
            { "e", "i" },
            { "ö", "ü" },
            { "o", "u" },
            { "ı", "ı" },
            { "i", "i" },
            { "u", "u" },
            { "ü", "ü" }
        };

        Dictionary<string, string> MINOR_HARMONY_FOR_FUTURE = new
        Dictionary<string, string>()
        {
            	{ "a", "a" },
          	{ "e", "e" },
	        { "ö", "e" },
	        { "o", "a" },
	        { "ı", "a" },
	        { "i", "e" },
	        { "u", "a" },
	        { "ü", "e" }
        };

        List<string> EXCEPTION_WORDS = new List<string>()
        { 
    	      "kontrol", "bandrol", "banal", "alpul", "ametal", "anormal", "amiral"
            , "sadakat", "santral", "şefkat", "usul", "normal", "oryantal", "hakikat"
            , "hayal", "saat", "kemal", "gol", "kalp", "metal", "faul", "mineral", "alkol"
            , "misal", "meal", "oramiral", "tuğamiral", "orjinal", "koramiral", "general"
            , "tümgeneral", "tuğgeneral", "korgeneral", "petrol", "liberal", "meral"
            , "metrapol", "ekümenapol", "lokal", "lügat", "liyakat", "legal", "mentol"
            , "beşamol", "meşgul", "meşekkat", "oval", "mahsul", "makul", "meraşal"
            , "metaryal", "nasihat", "radikal", "moral", "dikkat", "rol", "sinyal"
            , "sosyal", "total", "şevval", "sual", "spesiyal", "tuval", "turnusol", "hol"
            , "tropikal", "zeval", "zelal", "terminal", "termal", "resul", "sadakat", "resital"
            , "refakat", "pastoral", "hal", "müzikal", "müzikhol", "menkul", "mahmul", "maktul"
            , "kolestrol", "kıraat", "ziraaat", "kapital", "katedral", "kabul", "kanaat", "jurnal"
            , "kefal", "idrak", "istiklal", "integral", "final", "ekol", "emsal", "enternasyonal"
            , "nasyonal", "enstrümantal", "harf", "cemal", "cemaat", "glikol", "karambol", "parabol"
            , "kemal"
        };

        Dictionary<string, string> EXCEPTION_MISSING = new
        Dictionary<string, string>()
        { 
            { "isim","ism" },
            { "kasır","kasr" },
            { "kısım","kısm" },
            { "af","aff"},
            { "ilim","ilm"},
            //{ "hatır","hatr", # for daily usage only
            { "boyun","boyn"},
            { "nesil","nesl"},
            { "koyun","koyn"}, // koyun (sheep) or koyun (bosom)? for koyun (sheep) there is no exception but for koyun (bosom) there is. aaaaargh turkish!!
            { "karın","karn"} // same with this, karın (your wife) or karın (stomach)? for karın (your wife) there is not a such exception
            //{ katli, katle, katli etc. it doesn't really have a nominative case but only with suffixes?
        };

        public dynamic lastVowel(string word)
        {
            dynamic returndata = new ExpandoObject();

            word = word.makeLower();

            int vowel_count = 0;

            foreach (char lt in word.ToCharArray())
            {
                if (FRONT_VOWELS.Contains(lt.ToString()))
                {
                    vowel_count++;
                    returndata.letter = lt;
                    returndata.tone = "front";
                }
                else if (BACK_VOWELS.Contains(lt.ToString()))
                {
                    vowel_count++;
                    returndata.letter = lt;
                    returndata.tone = "back";
                }

            }

            // fake return for exception behaviour in Turkish
            if (EXCEPTION_WORDS.Contains(word))
            {
                if (returndata.letter == "o")
                {
                    returndata.letter = "ö";
                    returndata.tone = "back";
                }
                else if (returndata.letter == "a")
                {
                    returndata.letter = "e";
                    returndata.tone = "back";
                }
                else if (returndata.letter == "u")
                {
                    returndata.letter = "ü";
                    returndata.tone = "back";
                }
            }

            if (returndata.letter == ' ')
            {
                returndata.letter = "";
                returndata.tone = "back";
            }

            returndata.vowel_count = vowel_count;

            return returndata;
        }

        public dynamic lastLetter(string word)
        {

            dynamic returndata = new ExpandoObject();
            returndata.vowel = false; //ToDo: check

            word = word.makeLower();

            var getLastLetter = word.Substring(word.Length - 1);

            if (getLastLetter == "'")
                getLastLetter = word.Substring(word.Length - 2);

            returndata.letter = getLastLetter;


            if (VOWELS.Contains(getLastLetter))
            {
                returndata.vowel = true; // ToDo: Check

                if (FRONT_VOWELS.Contains(getLastLetter))
                    returndata.front_vowel = true;
                else
                    returndata.back_vowel = true;
            }

            else
            {
                returndata.consonant = true;

                if (HARD_CONSONANTS.Contains(getLastLetter))
                    returndata.hard_consonant = true;

                returndata.discontinious_hard_consonant_for_suffix = false;

                if (DISCONTINIOUS_HARD_CONSONANTS_AFTER_SUFFIX.Contains(getLastLetter))
                {
                    returndata.discontinious_hard_consonant_for_suffix = true;
                    getLastLetter = SOFTEN_DHC_AFTER_SUFFIX[DISCONTINIOUS_HARD_CONSONANTS_AFTER_SUFFIX.LastIndexOf(getLastLetter)].ToString();
                    returndata.soften_consonant_for_suffix = getLastLetter;
                }

            }

            return returndata;
        }

        public dynamic makeInfinitive(string word)
        {
            dynamic returndata = new ExpandoObject();

            if (lastVowel(word).tone = "front")
                returndata = word.concat("mak");
            else
                returndata = word.concat("mek");

            return returndata;
        }

        public string makePlural(string word, dynamic param = null)
        {
            string returndata = "";

            //if (param.proper_noun) // ToDo: Check
            //    word = word + "'";

            if (lastVowel(word).tone == "front")
                returndata = word.concat("lar");
            else
                returndata = word.concat("ler");

            return returndata;
        }

        public string makeAccusative(string word, dynamic param)
        {
            //firslty exceptions for o (he/she/it) 

            string returndata = "";

            string lowerWord = word.makeLower();

            bool proper_noun = param.proper_noun; //TryGetValue("proper_noun", out false);

            if (lowerWord == "o")
            {
                if (proper_noun = true)
                    returndata = word.fromUpperOrLower("O'nu");
                else
                    returndata = word.fromUpperOrLower("onu");
            }
            else
            {
                if (EXCEPTION_MISSING.ContainsKey(lowerWord) && proper_noun)
                {
                    word = word.fromUpperOrLower(EXCEPTION_MISSING[lowerWord]);
                    lowerWord = word.makeLower();
                }

                dynamic getLastLetter = lastLetter(word);
                dynamic getLastVowel = lastVowel(word);

                if (proper_noun)
                    word += "'";

                if (getLastLetter.vowel)
                    word = word.concat("y");

                else if (getLastLetter.discontinious_hard_consonant_for_suffix && proper_noun == false)
                {
                    if (getLastVowel.vowel_count > 1)
                    {
                        string soften_consonant_for_suffix = getLastLetter.soften_consonant_for_suffix;
                        word = word.Substring(0, word.Length - 1).concat(soften_consonant_for_suffix);
                    }
                }

                string letter = getLastVowel.letter.ToString();
                word = word.concat(MINOR_HARMONY[letter]); //ToDo check

                returndata = word;
            }

            return returndata;
        }

        public dynamic makeDative(string word, dynamic param)
        {

            //dynamic returndata = new ExpandoObject();
            string returndata;

            //firslty exceptions for ben (I) and you (sen)

            bool proper_noun = param.proper_noun; // param.get("proper_noun", false);
            string lowerWord = word.makeLower();

            if (proper_noun == true)
                word += "'";

            if (lowerWord == "ben" && proper_noun == false)
            {
                returndata = word.fromUpperOrLower("bana");
            }
            else if (lowerWord == "sen" && proper_noun == false)
            {
                returndata = word.fromUpperOrLower("sana");
            }
            else
            {
                if (EXCEPTION_MISSING.ContainsKey(lowerWord) && proper_noun == false)
                {
                    word = word.fromUpperOrLower(EXCEPTION_MISSING[lowerWord]);
                    lowerWord = word.makeLower();
                }

                dynamic getLastLetter = lastLetter(word);
                dynamic getLastVowel = lastVowel(word);

                if (getLastLetter.vowel == true)
                    word = word.concat("y");

                else if (getLastLetter.discontinious_hard_consonant_for_suffix == true)
                {
                    if (getLastVowel.vowel_count > 1 && proper_noun == false)
                    {
                        string soften_consonant_for_suffix = getLastLetter.soften_consonant_for_suffix;
                        word = word.Substring(0, word.Length - 1).concat(soften_consonant_for_suffix);
                    }
                }

                if (getLastVowel.tone == "front")
                    word = word.concat("a");
                else
                    word = word.concat("e");

                returndata = word;
            }

            if (returndata.isUpper())
                returndata = returndata.makeUpper();

            return returndata;
        }

        public string makeGenitive(string word, dynamic param)
        {

            dynamic getLastLetter = lastLetter(word);
            dynamic getLastVowel = lastVowel(word);

            string lowerWord = word.makeLower();
            string returndata = string.Empty;

            bool proper_noun = param.proper_noun;

            if (proper_noun == true)
                word += "'";

            if (EXCEPTION_MISSING.ContainsKey(lowerWord))
            {
                word = word.fromUpperOrLower(EXCEPTION_MISSING[lowerWord]);
                lowerWord = word.makeLower();
            }

            if (getLastLetter.vowel == true)
                word = word.concat("n");

            else if (getLastLetter.discontinious_hard_consonant_for_suffix && proper_noun == false)
            {
                if (getLastVowel.vowel_count > 1)
                {
                    string soften_consonant_for_suffix = getLastLetter.soften_consonant_for_suffix.ToString();
                    word = word.Substring(0, word.Length - 1).concat(soften_consonant_for_suffix); //ToDo: Check
                }
            }
            string letter = getLastVowel.letter.ToString();
            word = word.concat(MINOR_HARMONY[letter]); //ToDo: Check
            word = word.concat("n");

            returndata = word;

            return returndata;
        }
        
        public string makeAblative(string word, dynamic param)
        {

            string returndata = "";

            dynamic getLastLetter = lastLetter(word);
            dynamic getLastVowel = lastVowel(word);

            bool proper_noun = param.proper_noun;

            if (proper_noun)
                word += "'";

            if (HARD_CONSONANTS.Contains(getLastLetter.letter))
                word = word.concat("t");
            else
                word = word.concat("d");

            if (getLastVowel.tone == "front")
                word = word.concat("an");
            else
                word = word.concat("en");

            returndata = word;

            return returndata;
        }

        public string makeLocative(string word, dynamic param)
        {

            string returndata = "";

            dynamic getLastLetter = lastLetter(word);
            dynamic getLastVowel = lastVowel(word);

            bool proper_noun = param.proper_noun;

            if (proper_noun)
                word += "'";

            if (HARD_CONSONANTS.Contains(getLastLetter.letter)) //ToDo: Check
                word = word.concat("t");
            else
                word = word.concat("d");

            if (getLastVowel.tone == "front")
                word = word.concat("a");
            else
                word = word.concat("e");

            returndata = word;

            return returndata;
        }
        
        // İyelik ekleri
        public string possessiveAffix(string word, dynamic param)
        {

            string returndata = "";

            string person = param.person;
            string quantity = param.quantity;

            dynamic getLastLetter;
            dynamic getLastVowel;

            bool proper_noun = false; // param.proper_noun;

            if (person != "3" && quantity != "plural") // ToDo: not(!)
            {
                getLastLetter = lastLetter(word);
                getLastVowel = lastVowel(word);

                if (proper_noun)
                    word += "'";

                else if (getLastLetter.discontinious_hard_consonant_for_suffix)
                {
                    if (getLastVowel.vowel_count > 1)
                    {
                        string soften_consonant_for_suffix = getLastLetter.soften_consonant_for_suffix;
                        word = word.Substring(0, word.Length - 1).concat(soften_consonant_for_suffix);
                    }
                    if (EXCEPTION_MISSING.ContainsKey(word.makeLower())) // ToDo: Check
                        word = word.fromUpperOrLower(EXCEPTION_MISSING[word.makeLower()]);
                }
            }

            getLastLetter = lastLetter(word);
            getLastVowel = lastVowel(word);

            bool lastLetterIsVowel = VOWELS.Contains(getLastLetter.letter); // ToDo: Check return bool

            string letter = getLastVowel.letter.ToString();
            string minorHarmonyLetter = MINOR_HARMONY[letter];

            if (quantity == "singular")
            {
                if (lastLetterIsVowel == false)
                    word = word.concat(minorHarmonyLetter);

                if (person == "1")
                    word = word.concat("m");

                else if (person == "2")
                    word = word.concat("n");
            }
            else
            {
                if (person == "1")
                {
                    if (lastLetterIsVowel == false)
                        word = word.concat(minorHarmonyLetter);

                    word = word.concat("m");
                    word = word.concat(minorHarmonyLetter);
                    word = word.concat("z");
                }
                else if (person == "2")
                {
                    if (lastLetterIsVowel == false)
                        word = word.concat(minorHarmonyLetter);

                    word = word.concat("n");
                    word = word.concat(minorHarmonyLetter);
                    word = word.concat("z");
                }
                else
                {
                    if (word.makeLower() == "ism")
                    {
                        word = word.fromUpperOrLower("isim");
                    }
                    word = makePlural(word);
                    word = word.concat(minorHarmonyLetter);
                }

            }

            return word;
        }
        
    }

    public static class TrExtensions
    {

        public static bool IsUpperWord(this string value)
        {
            for (int i = 0; i < value.Length; i++)
                if (char.IsLower(value[i]))
                    return false;
            return true;
        }

        public static bool IsLowerWord(this string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsUpper(value[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool isUpper(this string word)
        {
            word = word.Replace("ı", "i").Replace("İ", "I").Replace("ş", "s").Replace("Ş", "S").Replace("ğ", "g").Replace("Ğ", "G").Replace("ü", "u").Replace("Ü", "U").Replace("ç", "c").Replace("Ç", "C").Replace("ö", "o").Replace("Ö", "O");
            return word.IsUpperWord();
        }

        public static string makeLower(this string word)
        {
            return word.Replace("İ", "i").Replace("I", "ı").ToLower();
        }

        public static string makeUpper(this string word)
        {
            return word.Replace("i", "İ").Replace("ı", "I").ToUpper();
        }

        public static string concat(this string str1, string str2)
        {
            string returndata = "";

            if (str1.isUpper())
                returndata = str1 + str2.makeUpper();
            else
                returndata = str1 + str2;

            return returndata;
        }

        public static string fromUpperOrLower(this string newWord, string refWord)
        {
            string returndata = string.Empty;

            if (refWord.Substring(refWord.Length - 1).isUpper())
                returndata = newWord.makeUpper();
            else
                if ((refWord.Substring(0)).isUpper())
                    returndata = newWord.Substring(0).makeUpper() + newWord.Substring(1, newWord.Length - 1).makeLower();
                else
                    returndata = newWord.makeLower();

            return returndata;
        }

    }

}
