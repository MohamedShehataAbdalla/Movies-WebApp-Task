﻿using System.Collections.Generic;

namespace Movies_WebApp.Code
{
    public class CountryData
    {
        public List<string> Countries = new List<string>
        {
            "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia",
            "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium",
            "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei",
            "Bulgaria", "Burkina Faso", "Burundi", "Cabo Verde", "Cambodia", "Cameroon", "Canada", "Central African Republic",
            "Chad", "Chile", "China", "Colombia", "Comoros", "Congo (Brazzaville)", "Congo (Kinshasa)", "Costa Rica",
            "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic",
            "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini",
            "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada",
            "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India",
            "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan",
            "Kazakhstan", "Kenya", "Kiribati", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho",
            "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", "Malawi", "Malaysia", "Maldives",
            "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco",
            "Mongolia", "Montenegro", "Morocco", "Mozambique", "Myanmar (Burma)", "Namibia", "Nauru", "Nepal",
            "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "North Korea", "North Macedonia", "Norway",
            "Oman", "Pakistan", "Palau", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines",
            "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia",
            "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal",
            "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia",
            "South Africa", "South Korea", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Sweden",
            "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tonga", "Trinidad and Tobago",
            "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom",
            "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Yemen", "Zambia",
            "Zimbabwe"
        };
        public Dictionary<string, List<string>> CountryToLanguages = new Dictionary<string, List<string>>
        {
            {"Afghanistan", new List<string> {"Pashto", "Dari"}},
            {"Albania", new List<string> {"Albanian"}},
            {"Algeria", new List<string> {"Arabic", "Berber"}},
            {"Andorra", new List<string> {"Catalan"}},
            {"Angola", new List<string> {"Portuguese"}},
            {"Antigua and Barbuda", new List<string> {"English"}},
            {"Argentina", new List<string> {"Spanish"}},
            {"Armenia", new List<string> {"Armenian"}},
            {"Australia", new List<string> {"English"}},
            {"Austria", new List<string> {"German"}},
            {"Azerbaijan", new List<string> {"Azerbaijani"}},
            {"Bahamas", new List<string> {"English"}},
            {"Bahrain", new List<string> {"Arabic"}},
            {"Bangladesh", new List<string> {"Bengali"}},
            {"Barbados", new List<string> {"English"}},
            {"Belarus", new List<string> {"Belarusian", "Russian"}},
            {"Belgium", new List<string> {"Dutch", "French", "German"}},
            {"Belize", new List<string> {"English"}},
            {"Benin", new List<string> {"French"}},
            {"Bhutan", new List<string> {"Dzongkha"}},
            {"Bolivia", new List<string> {"Spanish", "Quechua", "Aymara"}},
            {"Bosnia and Herzegovina", new List<string> {"Bosnian", "Croatian", "Serbian"}},
            {"Botswana", new List<string> {"English", "Setswana"}},
            {"Brazil", new List<string> {"Portuguese"}},
            {"Brunei", new List<string> {"Malay"}},
            {"Bulgaria", new List<string> {"Bulgarian"}},
            {"Burkina Faso", new List<string> {"French"}},
            {"Burundi", new List<string> {"Kirundi", "French"}},
            {"Cabo Verde", new List<string> {"Portuguese"}},
            {"Cambodia", new List<string> {"Khmer"}},
            {"Cameroon", new List<string> {"English", "French"}},
            {"Canada", new List<string> {"English", "French"}},
            {"Central African Republic", new List<string> {"French", "Sango"}},
            {"Chad", new List<string> {"Arabic", "French"}},
            {"Chile", new List<string> {"Spanish"}},
            {"China", new List<string> {"Mandarin"}},
            {"Colombia", new List<string> {"Spanish"}},
            {"Comoros", new List<string> {"Comorian", "Arabic", "French"}},
            {"Congo (Brazzaville)", new List<string> {"French"}},
            {"Congo (Kinshasa)", new List<string> {"French", "Lingala"}},
            {"Costa Rica", new List<string> {"Spanish"}},
            {"Croatia", new List<string> {"Croatian"}},
            {"Cuba", new List<string> {"Spanish"}},
            {"Cyprus", new List<string> {"Greek", "Turkish"}},
            {"Czech Republic", new List<string> {"Czech"}},
            {"Denmark", new List<string> {"Danish"}},
            {"Djibouti", new List<string> {"French", "Arabic"}},
            {"Dominica", new List<string> {"English"}},
            {"Dominican Republic", new List<string> {"Spanish"}},
            {"East Timor", new List<string> {"Portuguese", "Tetum"}},
            {"Ecuador", new List<string> {"Spanish"}},
            {"Egypt", new List<string> {"Arabic"}},
            {"El Salvador", new List<string> {"Spanish"}},
            {"Equatorial Guinea", new List<string> {"Spanish", "French", "Portuguese"}},
            {"Eritrea", new List<string> {"Tigrigna", "Tigre", "Arabic"}},
            {"Estonia", new List<string> {"Estonian"}},
            {"Eswatini", new List<string> {"Swazi (SiSwati)", "English"}},
            {"Ethiopia", new List<string> {"Amharic", "Oromo", "Tigrigna"}},
            {"Fiji", new List<string> {"English", "Fijian", "Hindi"}},
            {"Finland", new List<string> {"Finnish", "Swedish"}},
            {"France", new List<string> {"French"}},
            {"Gabon", new List<string> {"French"}},
            {"Gambia", new List<string> {"English"}},
            {"Georgia", new List<string> {"Georgian"}},
            {"Germany", new List<string> {"German"}},
            {"Ghana", new List<string> {"English"}},
            {"Greece", new List<string> {"Greek"}},
            {"Grenada", new List<string> {"English"}},
            {"Guatemala", new List<string> {"Spanish"}},
            {"Guinea", new List<string> {"French"}},
            {"Guinea-Bissau", new List<string> {"Portuguese"}},
            {"Guyana", new List<string> {"English"}},
            {"Haiti", new List<string> {"French", "Haitian Creole"}},
            {"Honduras", new List<string> {"Spanish"}},
            {"Hungary", new List<string> {"Hungarian"}},
            {"Iceland", new List<string> {"Icelandic"}},
            {"India", new List<string> {"Hindi", "Bengali", "Telugu", "Marathi", "Tamil", "Urdu", "Gujarati", "Kannada", "Oriya", "Punjabi", "Malayalam", "Assamese", "Kashmiri", "Sanskrit", "Nepali", "Sindhi", "Konkani", "Manipuri", "Khasi", "Mizo", "Bodo", "Santhali", "Maithili", "Dogri"}},
            {"Indonesia", new List<string> {"Indonesian"}},
            {"Iran", new List<string> {"Persian"}},
            {"Iraq", new List<string> {"Arabic", "Kurdish"}},
            {"Ireland", new List<string> {"English", "Irish"}},
            {"Israel", new List<string> {"Hebrew", "Arabic"}},
            {"Italy", new List<string> {"Italian"}},
            {"Ivory Coast", new List<string> {"French"}},
            {"Jamaica", new List<string> {"English"}},
            {"Japan", new List<string> {"Japanese"}},
            {"Jordan", new List<string> {"Arabic"}},
            {"Kazakhstan", new List<string> {"Kazakh", "Russian"}},
            {"Kenya", new List<string> {"Swahili", "English"}},
            {"Kiribati", new List<string> {"English", "Gilbertese"}},
            {"Kosovo", new List<string> {"Albanian", "Serbian"}},
            {"Kuwait", new List<string> {"Arabic"}},
            {"Kyrgyzstan", new List<string> {"Kyrgyz", "Russian"}},
            {"Laos", new List<string> {"Lao"}},
            {"Latvia", new List<string> {"Latvian"}},
            {"Lebanon", new List<string> {"Arabic"}},
            {"Lesotho", new List<string> {"Sesotho", "English"}},
            {"Liberia", new List<string> {"English"}},
            {"Libya", new List<string> {"Arabic"}},
            {"Liechtenstein", new List<string> {"German"}},
            {"Lithuania", new List<string> {"Lithuanian"}},
            {"Luxembourg", new List<string> {"Luxembourgish", "French", "German"}},
            {"Madagascar", new List<string> {"Malagasy", "French"}},
            {"Malawi", new List<string> {"English", "Chichewa"}},
            {"Malaysia", new List<string> {"Malay"}},
            {"Maldives", new List<string> {"Dhivehi"}},
            {"Mali", new List<string> {"French"}},
            {"Malta", new List<string> {"Maltese", "English"}},
            {"Marshall Islands", new List<string> {"English", "Marshallese"}},
            {"Mauritania", new List<string> {"Arabic"}},
            {"Mauritius", new List<string> {"English", "French"}},
            {"Mexico", new List<string> {"Spanish"}},
            {"Micronesia", new List<string> {"English"}},
            {"Moldova", new List<string> {"Moldovan (Romanian)", "Russian", "Gagauz"}},
            {"Monaco", new List<string> {"French"}},
            {"Mongolia", new List<string> {"Khalkha Mongol"}},
            {"Montenegro", new List<string> {"Serbian", "Montenegrin"}},
            {"Morocco", new List<string> {"Arabic", "Berber"}},
            {"Mozambique", new List<string> {"Portuguese"}},
            {"Myanmar (Burma)", new List<string> {"Burmese"}},
            {"Namibia", new List<string> {"English", "Afrikaans", "German"}},
            {"Nauru", new List<string> {"Nauruan", "English"}},
            {"Nepal", new List<string> {"Nepali"}},
            {"Netherlands", new List<string> {"Dutch"}},
            {"New Zealand", new List<string> {"English", "Maori"}},
            {"Nicaragua", new List<string> {"Spanish"}},
            {"Niger", new List<string> {"French"}},
            {"Nigeria", new List<string> {"English"}},
            {"North Korea", new List<string> {"Korean"}},
            {"North Macedonia", new List<string> {"Macedonian"}},
            {"Norway", new List<string> {"Norwegian"}},
            {"Oman", new List<string> {"Arabic"}},
            {"Pakistan", new List<string> {"Urdu", "English"}},
            {"Palau", new List<string> {"English", "Palauan"}},
            {"Palestine", new List<string> {"Arabic"}},
            {"Panama", new List<string> {"Spanish"}},
            {"Papua New Guinea", new List<string> {"English"}},
            {"Paraguay", new List<string> {"Spanish", "Guarani"}},
            {"Peru", new List<string> {"Spanish", "Quechua"}},
            {"Philippines", new List<string> {"Filipino (Tagalog)", "English"}},
            {"Poland", new List<string> {"Polish"}},
            {"Portugal", new List<string> {"Portuguese"}},
            {"Qatar", new List<string> {"Arabic"}},
            {"Romania", new List<string> {"Romanian"}},
            {"Russia", new List<string> {"Russian"}},
            {"Rwanda", new List<string> {"Kinyarwanda", "French", "English"}},
            {"Saint Kitts and Nevis", new List<string> {"English"}},
            {"Saint Lucia", new List<string> {"English"}},
            {"Saint Vincent and the Grenadines", new List<string> {"English"}},
            {"Samoa", new List<string> {"Samoan", "English"}},
            {"San Marino", new List<string> {"Italian"}},
            {"Sao Tome and Principe", new List<string> {"Portuguese"}},
            {"Saudi Arabia", new List<string> {"Arabic"}},
            {"Senegal", new List<string> {"French"}},
            {"Serbia", new List<string> {"Serbian"}},
            {"Seychelles", new List<string> {"Seychellois Creole", "English", "French"}},
            {"Sierra Leone", new List<string> {"English"}},
            {"Singapore", new List<string> {"English", "Malay", "Mandarin", "Tamil"}},
            {"Slovakia", new List<string> {"Slovak"}},
            {"Slovenia", new List<string> {"Slovene"}},
            {"Solomon Islands", new List<string> {"English"}},
            {"Somalia", new List<string> {"Somali", "Arabic"}},
            {"South Africa", new List<string> {"Zulu", "Xhosa", "Afrikaans", "English"}},
            {"South Korea", new List<string> {"Korean"}},
            {"South Sudan", new List<string> {"English", "Arabic"}},
            {"Spain", new List<string> {"Spanish"}},
            {"Sri Lanka", new List<string> {"Sinhala", "Tamil"}},
            {"Sudan", new List<string> {"Arabic", "English"}},
            {"Suriname", new List<string> {"Dutch"}},
            {"Sweden", new List<string> {"Swedish"}},
            {"Switzerland", new List<string> {"German", "French", "Italian", "Romansh"}},
            {"Syria", new List<string> {"Arabic"}},
            {"Taiwan", new List<string> {"Mandarin"}},
            {"Tajikistan", new List<string> {"Tajik"}},
            {"Tanzania", new List<string> {"Swahili", "English"}},
            {"Thailand", new List<string> {"Thai"}},
            {"Togo", new List<string> {"French"}},
            {"Tonga", new List<string> {"Tongan", "English"}},
            {"Trinidad and Tobago", new List<string> {"English"}},
            {"Tunisia", new List<string> {"Arabic"}},
            {"Turkey", new List<string> {"Turkish"}},
            {"Turkmenistan", new List<string> {"Turkmen"}},
            {"Tuvalu", new List<string> {"English", "Tuvaluan"}},
            {"Uganda", new List<string> {"English", "Swahili"}},
            {"Ukraine", new List<string> {"Ukrainian", "Russian"}},
            {"United Arab Emirates", new List<string> {"Arabic"}},
            {"United Kingdom", new List<string> {"English"}},
            {"United States", new List<string> {"English"}},
            {"Uruguay", new List<string> {"Spanish"}},
            {"Uzbekistan", new List<string> {"Uzbek"}},
            {"Vanuatu", new List<string> {"Bislama", "English", "French"}},
            {"Vatican City", new List<string> {"Italian", "Latin"}},
            {"Venezuela", new List<string> {"Spanish"}},
            {"Vietnam", new List<string> {"Vietnamese"}},
            {"Yemen", new List<string> {"Arabic"}},
            {"Zambia", new List<string> {"English"}},
            {"Zimbabwe", new List<string> {"English", "Chewa", "Chibarwe", "Kalenjin", "Khoekhoe", "Nambya", "Ndau", "Ndebele", "Shangani", "Shona", "Sinhala", "Sotho", "Tonga", "Tswana", "Venda", "Xhosa", "Zulu"}},
        };

    }
}
