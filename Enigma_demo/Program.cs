﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Enigma_demo
{
    class Program
    {
        private static object rotors;

        static String Encryption()
        {
            String text = "OneofthekeyobjectivesfortheAlliesduringWWIIwastofindawaytobreakthecodetobeabletodecryptGermancommunicationsAteamofPolishcryptanalystswasthefirsttobreak";
            text = text.ToLower();
            Console.WriteLine(text+"                 **");
            String[] abc = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            String abc2 = "abcdefghijklmnopqrstuvwxyz";
            int[] count = new int[26];
            int[] count2 = new int[26];
            int[] Letter_rating = { 3,19,12,9,1,16,17,8,5,22,21,10,14,6,4,18,22,8,7,2,11,20,13,22,15,23};
            int[] Letter_rating2 = new int[26];

            int key1 = 2;
            int key2 = 25;
            int key3 = 8;
            
            int cont_key1 = 0;
            int cont_key2 = 0;
            int cont = 5;

            String Encrypted_text = "";
            String Encrypted_text2 = "";
            String Encrypted_text3 = "";
            int i;
            int c = 0;


            for (i = 0; i < text.Length; i++)
            {
                if (abc2.IndexOf(text[i]) != -1)
                {
                  //  text[i] = "";
                    count[abc2.IndexOf(text[i])]++;

                }
                //-------------------------------------------Rotor1-------------------------------------------------------------
                if (cont_key1 > 25)
                {
                    key2++;
                    cont_key1 = 0;
                    if (key2 > 25)
                    {
                        key2 = 0;
                    }
                }
                else
                {
                    cont_key1++;
                }

                if (abc2.IndexOf(text[i]) == -1)
                {
                    Encrypted_text = Encrypted_text + "";
                    cont++;
                }
                else if (abc2.IndexOf(text[i]) + key1 > 25)
                {
                    Encrypted_text = Encrypted_text + abc2[abc2.IndexOf(text[i]) + key1 - 26];
                }
                else
                    Encrypted_text = Encrypted_text + abc2[abc2.IndexOf(text[i]) + key1];
                key1++;
                if (key1 > 25)
                {
                    key1 = 0;
                }

                //-------------------------------------------Rotor2-------------------------------------------------------------
                if (cont_key2 > 25)
                {
                    key3++;
                    cont_key2 = 0;
                    if (key3 > 25)
                    {
                        key3 = 0;
                    }
                }
                else
                {
                    cont_key2++;
                }

                if (abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2 > 25)
                {
                    Encrypted_text2 = Encrypted_text2 + abc2[abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2 - 26];
                }
                else
                    Encrypted_text2 = Encrypted_text2 + abc2[abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2];

                if (key2 > 25)
                {
                    key2 = 0;
                }

                //-------------------------------------------Rotor3-------------------------------------------------------------


                if (abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3 > 25)
                {
                    Encrypted_text3 = Encrypted_text3 + abc2[abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3 - 26];
                }
                else
                    Encrypted_text3 = Encrypted_text3 + abc2[abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3];





            }
            /**/ Console.WriteLine(Encrypted_text);
             Console.WriteLine(Encrypted_text2);
             Console.WriteLine(Encrypted_text3);

            for(i = 0; i < 26; i++) {
                Console.WriteLine(abc2[i] + " - " + count[i]);
                count2[i] = count[i]; }
            
           /*  Array.Sort(count2);
          
            
           for (i = 0; i < 26; i++)
            {
               for(int j = 0; j < 26; j++)
                {
                    if (c > 25)
                    {
                        break;
                    }
                    if (count[i] == count2[j])
                    {
                        Letter_rating2[c++] = (26-j);
                        Console.WriteLine(c+"- "+abc2[c-1]+" - "+ Letter_rating2[c - 1]+" " +count[i]);
                        break;
                    }
                }
            }*/

            return Encrypted_text3;

        }
        static void Deciphering(String textEncryption)

        {
            String text = textEncryption;

            String[] abc = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            String abc2 = "abcdefghijklmnopqrstuvwxyz";
            int key1 = 0;
            int key2 = 0;
            int key3 = 0;
            int cont = 0;
            String Result="";
            int i;
            int i2;

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;

            int max = 0;
            for (i2 = 0; i2 < Math.Pow(26, 3); i2++)
            {


                int cont_key1 = 0;
                int cont_key2 = 0;
                int cont_key3 = 0;

                String Encrypted_text = "";
                String Encrypted_text2 = "";
                String Encrypted_text3 = "";

                for (i = 0; i < text.Length; i++)
                {

                    //-------------------------------------------Rotor1-------------------------------------------------------------
                    if (cont_key1 > 25)
                    {
                        cont_key1 = 0;
                        key2--;
                        if (key2 < 0)
                        {
                            key2 = 25;
                        }
                    }
                    else
                    {
                        cont_key1++;
                    }

                    if (abc2.IndexOf(text[i]) == -1)
                    {
                        Encrypted_text = Encrypted_text + "";
                        cont++;
                    }
                    else if (abc2.IndexOf(text[i]) + key1 > 25)
                    {
                        Encrypted_text = Encrypted_text + abc2[abc2.IndexOf(text[i]) + key1 - 26];
                    }
                    else
                        Encrypted_text = Encrypted_text + abc2[abc2.IndexOf(text[i]) + key1];
                    key1--;
                    if (key1 < 0)
                    {
                        key1 = 25;
                    }

                    //-------------------------------------------Rotor2-------------------------------------------------------------
                    if (cont_key2 > 25)
                    {
                        cont_key2 = 0;
                        key3--;
                        if (key3 < 0)
                        {
                            key3 = 25;
                        }
                    }
                    else
                    {
                        cont_key2++;
                    }

                    if (abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2 > 25)
                    {
                        Encrypted_text2 = Encrypted_text2 + abc2[abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2 - 26];
                    }
                    else
                        Encrypted_text2 = Encrypted_text2 + abc2[abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2];

                    if (key2 < 0)
                    {
                        key2 = 25;
                    }

                    //-------------------------------------------Rotor3-------------------------------------------------------------


                    if (abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3 > 25)
                    {
                        Encrypted_text3 = Encrypted_text3 + abc2[abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3 - 26];
                    }
                    else
                        Encrypted_text3 = Encrypted_text3 + abc2[abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3];





                }
                if (num1 == 25)
                {
                    num1 = 0;
                    num2++;
                }
                if (num2 > 25)
                {
                    num2 = 0;
                    num3++;
                }
                if (num3 > 25)
                {
                    num3 = 0;
                    Console.WriteLine(i2);
                }
                key1 = ++num1;
                key2 = num2;
                key3 = num3;

                if (Frequency_analysis(Encrypted_text3) > max)
                {
                    max = Frequency_analysis(Encrypted_text3);
                    Result = Encrypted_text3;
                    Console.WriteLine(max + " max "+ Encrypted_text3);
                }
                if (Encrypted_text3 == "oneofthekeyobjectivesforthealliesduringwwiiwastofindawaytobreakthecodetobeabletodecryptgermancommunicationsateamofpolishcryptanalystswasthefirsttobreak")
                {
                    /* Console.WriteLine(Encrypted_text);
                     Console.WriteLine(Encrypted_text2);*/
                    cont++;
                    /*  Console.WriteLine(Encrypted_text3+" "+cont);
                                   Console.WriteLine("key1 "+ key1+" key2 "+key2+" key3 "+key3);*/
                }

            }
            Console.WriteLine("key1 " + key1 + " key2 " + key2 + " key3 " + key3 + " cont " + cont + " " + i2);
            Console.WriteLine(Result);
        }

        static int Frequency_analysis(String str_analysis)
        {
            String abc2 = "abcdefghijklmnopqrstuvwxyz";
            int[] count = new int[26];
            int[] count2 = new int[26];
            int[] Letter_rating = { 3, 19, 12, 9, 1, 16, 17, 8, 5, 22, 21, 10, 14, 6, 4, 18, 22, 8, 7, 2, 11, 20, 13, 22, 15, 23 };
            int[] Letter_rating2 = new int[26];
            int max =0;

            int i;
            int c = 0;

            for (i = 0; i < str_analysis.Length; i++)
            {

                if (abc2.IndexOf(str_analysis[i]) != -1)
                {

                    count[abc2.IndexOf(str_analysis[i])]++;

                }
                /* Console.WriteLine(abc2[i] + " - " + count[i]);
                 count2[i] = count[i];*/

            }
            for (i = 0; i < 26; i++)
            {
               // Console.WriteLine(abc2[i] + " - " + count[i]);
                count2[i] = count[i];
            }

            Array.Sort(count2);


            for (i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (c > 25)
                    {
                        break;
                    }
                    if (count[i] == count2[j])
                    {
                        Letter_rating2[c++] = (26 - j);
                       // Console.WriteLine(c + "- " + abc2[c - 1] + " - " + Letter_rating2[c - 1] + " " + count[i]);
                        if(Letter_rating2[c - 1] == Letter_rating[c - 1]|| Letter_rating2[c - 1] == Letter_rating[c - 1]+1 || Letter_rating2[c - 1] == Letter_rating[c - 1]+2 || Letter_rating2[c - 1] == Letter_rating[c - 1]+3 || Letter_rating2[c - 1] == Letter_rating[c - 1]-1 || Letter_rating2[c - 1] == Letter_rating[c - 1]-2 || Letter_rating2[c - 1] == Letter_rating[c - 1]-3)
                        {
                            max++;
                        }
                        break;
                    }
                }
            }
            return max;
        }

        static void Main(string[] args)
        {



            /*var exeFolder = AppDomain.CurrentDomain.BaseDirectory;
            var filename = Path.Combine(exeFolder, "json1.json");

            var json = File.ReadAllText(filename);

            var key = JsonConvert.DeserializeObject<KeyModel>(json);*/

            //   Console.WriteLine(Encryption());
            //   Deciphering(Encryption());

            /*EnigmaSettings enigmaSettings = new EnigmaSettings()
            {

                rotor1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ",
                rotor2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE",
                rotor3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO",
                rotor4 = "ESOVPZJAYQUIRHXLNFTGKDCMWB",

                reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT"
            };*/

            /* double[] Letter_rating2 = { 0.0651738, 0.0124248, 0.0217339, 0.0349835, 0.1041442, 0.0197881, 0.0158610, 0.0492888, 0.0558094, 0.0009033, 0.0050529, 0.0331490, 0.0202124, 0.0564513, 0.0596302, 0.0137645, 0.0008606, 0.0497563, 0.0515760, 0.0729357, 0.0225134, 0.0082903, 0.0171272, 0.0013692, 0.0145984, 0.0007836, 0.1918182 };

             Array.Sort(Letter_rating2);

             foreach (double e in Letter_rating2)
                 Console.WriteLine(e);*/

            String[] abc = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "SPACE" };

            double[,] a = {
                  { 0.0002835, 0.0228302, 0.0369041, 0.0426290, 0.0012216, 0.0075739, 0.0171385, 0.0014659, 0.0372661, 0.0002353, 0.0110124, 0.0778259, 0.0260757, 0.2145354, 0.0005459, 0.0195213, 0.0001749, 0.1104770, 0.0934290, 0.1317960, 0.0098029, 0.0306574, 0.0088799, 0.0009562, 0.0233701, 0.0018701, 0.0715219 },
                  { 0.0580027, 0.0058699, 0.0000791, 0.0022625, 0.3416714, 0.0002057, 0.0004272, 0.0003639, 0.0479084, 0.0076894, 0.0000000, 0.1150560, 0.0012816, 0.0003481, 0.0966553, 0.0000158, 0.0000000, 0.0740301, 0.0226884, 0.0107430, 0.1196127, 0.0011550, 0.0000316, 0.0000000, 0.0864502, 0.0000000, 0.0074521 },
                  { 0.1229841, 0.0000271, 0.0215451, 0.0005246, 0.1715916, 0.0000090, 0.0000000, 0.1701716, 0.0565490, 0.0000000, 0.0453966, 0.0488879, 0.0000000, 0.0000362, 0.1759242, 0.0000090, 0.0017185, 0.0376812, 0.0010492, 0.0906756, 0.0358361, 0.0000000, 0.0000000, 0.0000000, 0.0041969, 0.0000090, 0.0151774 },
                  { 0.0280345, 0.0005057, 0.0002585, 0.0081086, 0.1224833, 0.0006799, 0.0054844, 0.0007080, 0.0794902, 0.0003484, 0.0001911, 0.0092662, 0.0021466, 0.0030456, 0.0397283, 0.0001630, 0.0000225, 0.0178918, 0.0307037, 0.0009159, 0.0178805, 0.0027759, 0.0013655, 0.0000000, 0.0076478, 0.0000000, 0.6201541 },
                  { 0.0545873, 0.0012798, 0.0224322, 0.0843434, 0.0317097, 0.0085640, 0.0052834, 0.0017762, 0.0127186, 0.0002605, 0.0010967, 0.0339975, 0.0186268, 0.0815271, 0.0032334, 0.0101307, 0.0021424, 0.1307517, 0.0712793, 0.0241537, 0.0014289, 0.0157312, 0.0070879, 0.0105139, 0.0125997, 0.0001831, 0.3525610 },
                  { 0.0638579, 0.0002384, 0.0003179, 0.0002086, 0.0928264, 0.0500293, 0.0000199, 0.0000993, 0.0820576, 0.0000000, 0.0000199, 0.0266638, 0.0000397, 0.0000894, 0.1545186, 0.0001689, 0.0000099, 0.0825344, 0.0039539, 0.0341940, 0.0334986, 0.0000099, 0.0001987, 0.0000000, 0.0015200, 0.0000000, 0.3729250 },
                  { 0.0592435, 0.0003842, 0.0005205, 0.0020078, 0.1482326, 0.0002727, 0.0101631, 0.1420108, 0.0501091, 0.0000248, 0.0000372, 0.0395122, 0.0029870, 0.0127906, 0.0573224, 0.0005577, 0.0000000, 0.0884686, 0.0261142, 0.0062466, 0.0256309, 0.0000372, 0.0003470, 0.0000000, 0.0032720, 0.0001363, 0.3235710 },
                  { 0.1580232, 0.0007737, 0.0020460, 0.0005185, 0.4597035, 0.0004627, 0.0000359, 0.0000718, 0.1252667, 0.0000000, 0.0000040, 0.0014278, 0.0013042, 0.0012922, 0.0700557, 0.0000439, 0.0003191, 0.0117178, 0.0022056, 0.0297253, 0.0131497, 0.0000000, 0.0010290, 0.0000000, 0.0072309, 0.0000000, 0.1135928 },
                  { 0.0166996, 0.0069144, 0.0486793, 0.0363474, 0.0480664, 0.0271435, 0.0307856, 0.0000775, 0.0004826, 0.0000035, 0.0073125, 0.0526842, 0.0412929, 0.2618995, 0.0497818, 0.0062698, 0.0004333, 0.0437620, 0.1157982, 0.1198384, 0.0007010, 0.0235788, 0.0000211, 0.0018810, 0.0000000, 0.0032265, 0.0563193 },
                  { 0.2106638, 0.0000000, 0.0000000, 0.0000000, 0.1906420, 0.0000000, 0.0000000, 0.0000000, 0.0004353, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.2644178, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.3299238, 0.0000000, 0.0000000, 0.0000000, 0.0002176, 0.0000000, 0.0036997 },
                  { 0.0169234, 0.0011671, 0.0005058, 0.0017118, 0.3321662, 0.0041628, 0.0004669, 0.0007781, 0.1300965, 0.0000000, 0.0003112, 0.0185963, 0.0009726, 0.1009570, 0.0113601, 0.0012060, 0.0000000, 0.0004279, 0.0613523, 0.0022954, 0.0029956, 0.0000000, 0.0041239, 0.0000000, 0.0086757, 0.0000000, 0.2987473 },
                  { 0.1016800, 0.0005515, 0.0020459, 0.0668636, 0.1657445, 0.0134024, 0.0011801, 0.0001542, 0.1107889, 0.0000119, 0.0053728, 0.1355180, 0.0055389, 0.0009726, 0.0826499, 0.0022654, 0.0000059, 0.0018443, 0.0230153, 0.0180635, 0.0144461, 0.0041630, 0.0025797, 0.0000000, 0.0968765, 0.0000237, 0.1442414 },
                  { 0.1539307, 0.0285939, 0.0001653, 0.0025384, 0.2496134, 0.0017798, 0.0000195, 0.0003015, 0.0877464, 0.0000195, 0.0000000, 0.0015756, 0.0221846, 0.0029567, 0.1098532, 0.0485124, 0.0000000, 0.0169910, 0.0249954, 0.0008461, 0.0385435, 0.0000292, 0.0001167, 0.0000000, 0.0505257, 0.0000000, 0.1581614 },
                  { 0.0240107, 0.0005432, 0.0423173, 0.1767352, 0.0849166, 0.0053036, 0.1188694, 0.0028799, 0.0295789, 0.0012223, 0.0071353, 0.0087755, 0.0006582, 0.0085073, 0.0653564, 0.0003343, 0.0009716, 0.0004144, 0.0427003, 0.0956004, 0.0093814, 0.0033500, 0.0008497, 0.0003343, 0.0121150, 0.0001288, 0.2570099 },
                  { 0.0083175, 0.0072923, 0.0127087, 0.0203076, 0.0029439, 0.1135873, 0.0060659, 0.0018527, 0.0087857, 0.0001978, 0.0106912, 0.0268647, 0.0580447, 0.1459838, 0.0330625, 0.0138659, 0.0002308, 0.1175433, 0.0322680, 0.0492657, 0.1337201, 0.0164801, 0.0488371, 0.0005374, 0.0033923, 0.0008571, 0.1262960 },
                  { 0.1284508, 0.0004427, 0.0004427, 0.0004713, 0.2213542, 0.0001428, 0.0000857, 0.0221226, 0.0538854, 0.0000286, 0.0001143, 0.0957597, 0.0010854, 0.0005856, 0.1212242, 0.0607692, 0.0000000, 0.1362487, 0.0222939, 0.0408603, 0.0270926, 0.0000000, 0.0011711, 0.0000000, 0.0042274, 0.0000000, 0.0611405 },
                  { 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0002284, 0.0002284, 0.0000000, 0.9949749, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0000000, 0.0045683 },
                  { 0.0733524, 0.0032081, 0.0116789, 0.0284070, 0.2345530, 0.0056616, 0.0107385, 0.0026432, 0.0792432, 0.0000435, 0.0087196, 0.0117263, 0.0192448, 0.0221961, 0.0919374, 0.0048043, 0.0000316, 0.0189406, 0.0459213, 0.0421561, 0.0173721, 0.0070603, 0.0019873, 0.0000040, 0.0284504, 0.0055945, 0.2243241 },
                  { 0.0349781, 0.0006441, 0.0157796, 0.0015208, 0.1179849, 0.0010558, 0.0004688, 0.0569819, 0.0506053, 0.0000495, 0.0053780, 0.0114497, 0.0065520, 0.0022488, 0.0491264, 0.0287844, 0.0008309, 0.0001906, 0.0463897, 0.1269191, 0.0330152, 0.0000800, 0.0053856, 0.0000000, 0.0020925, 0.0000000, 0.4014880 },
                  { 0.0393295, 0.0001590, 0.0037195, 0.0000674, 0.0892434, 0.0009218, 0.0000404, 0.3352928, 0.0666758, 0.0000054, 0.0000162, 0.0146273, 0.0009110, 0.0011051, 0.0913053, 0.0000809, 0.0000027, 0.0310281, 0.0245378, 0.0171177, 0.0185732, 0.0000027, 0.0078702, 0.0000000, 0.0121422, 0.0002776, 0.2449470 },
                  { 0.0261517, 0.0181796, 0.0459729, 0.0223272, 0.0308931, 0.0058765, 0.0505571, 0.0000699, 0.0298191, 0.0000087, 0.0001572, 0.1066327, 0.0308669, 0.1156002, 0.0020170, 0.0448465, 0.0001746, 0.1626908, 0.1207345, 0.1249869, 0.0000349, 0.0009343, 0.0002008, 0.0008819, 0.0002969, 0.0010042, 0.0580839 },
                  { 0.1022242, 0.0000000, 0.0000000, 0.0049559, 0.6796927, 0.0000000, 0.0000000, 0.0002371, 0.1467561, 0.0000000, 0.0000000, 0.0001423, 0.0000000, 0.0128284, 0.0429195, 0.0000000, 0.0000000, 0.0008299, 0.0003083, 0.0000000, 0.0025847, 0.0005928, 0.0000000, 0.0000000, 0.0038888, 0.0000000, 0.0020393 },
                  { 0.1832539, 0.0003329, 0.0002984, 0.0018938, 0.1605624, 0.0013085, 0.0000344, 0.1893372, 0.1788924, 0.0000000, 0.0005050, 0.0089412, 0.0002755, 0.0372798, 0.0933831, 0.0000803, 0.0000115, 0.0082066, 0.0126485, 0.0018135, 0.0011707, 0.0000000, 0.0003214, 0.0000000, 0.0006887, 0.0000000, 0.1187604 },
                  { 0.0600144, 0.0000000, 0.1573582, 0.0010050, 0.0554200, 0.0000000, 0.0001436, 0.0132089, 0.1122757, 0.0000000, 0.0000000, 0.0014358, 0.0001436, 0.0000000, 0.0055994, 0.2157933, 0.0031587, 0.0000000, 0.0027279, 0.2360373, 0.0195262, 0.0051687, 0.0001436, 0.0093324, 0.0020101, 0.0000000, 0.0994975 },
                  { 0.0072178, 0.0039321, 0.0011985, 0.0020738, 0.0562745, 0.0015217, 0.0003097, 0.0007137, 0.0141393, 0.0000135, 0.0000269, 0.0031914, 0.0039051, 0.0022488, 0.1205478, 0.0027875, 0.0000000, 0.0048882, 0.0324935, 0.0109613, 0.0005925, 0.0000673, 0.0016025, 0.0001347, 0.0000943, 0.0002020, 0.7288617 },
                  { 0.4219769, 0.0007526, 0.0060211, 0.0067737, 0.3038133, 0.0000000, 0.0000000, 0.0005018, 0.0709985, 0.0002509, 0.0000000, 0.0198194, 0.0000000, 0.0000000, 0.0730055, 0.0000000, 0.0000000, 0.0002509, 0.0017561, 0.0005018, 0.0037632, 0.0010035, 0.0000000, 0.0000000, 0.0100351, 0.0268440, 0.0519318 },
                  { 0.1062437, 0.0444502, 0.0391600, 0.0282947, 0.0213084, 0.0400793, 0.0171783, 0.0606047, 0.0678165, 0.0034660, 0.0045451, 0.0243019, 0.0406429, 0.0234882, 0.0649920, 0.0273498, 0.0022208, 0.0214068, 0.0704687, 0.1460781, 0.0092399, 0.0079497, 0.0606385,  0.0001107,  0.0114638,  0.0002911, 0.0562102}
        };

            double[] Letter_rating2 = new double[27];
            int i;
           
            for (i = 0; i < 27; i++)
            {
                for(int c = 0; c < 27; c++)
                {
                    Letter_rating2[c] = a[i, c];
                 
                }
                Array.Sort(Letter_rating2);
                int cunt = 0;
                foreach (double e in Letter_rating2)
                    
                for (int c = 0; c < 27; c++)
                    {
                        if(e == a[i, c]) {
                          cunt++;
                          Console.WriteLine(cunt + "- "+e +" index: "+c+","+i+"--> "+ abc[c]+ abc[i]);
                            
                            break;
                        }
                    

                    }
                
                    
                       Console.WriteLine("----------------------------------------------------------------------------------------");
            }

        }
    }
    public class EnigmaSettings
    {
        public string rotor1 { get; set; }
        public string rotor2 { get; set; }
        public string rotor3 { get; set; }
        public string rotor4 { get; set; }
        public string rotor5 { get; set; }

      public string reflector { get; set; }

       /*   public List<EnigmaSettings> list { get; set; }*/
    }
}
