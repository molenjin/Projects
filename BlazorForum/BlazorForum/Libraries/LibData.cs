﻿using System.Drawing;

namespace BlazorForum.Libraries
{
    public class LibData
    {
        public static string CountryName(string countryCode)
        {
            string code = countryCode.ToUpper();
            string country = code;

            if (code == "AF") country = "Afghanistan";
            if (code == "AX") country = "Aland Islands";
            if (code == "AL") country = "Albania";
            if (code == "DZ") country = "Algeria";
            if (code == "AS") country = "American Samoa";
            if (code == "AD") country = "Andorra";
            if (code == "AO") country = "Angola";
            if (code == "AI") country = "Anguilla";
            if (code == "AQ") country = "Antarctica";
            if (code == "AG") country = "Antigua and Barbuda";
            if (code == "AR") country = "Argentina";
            if (code == "AM") country = "Armenia";
            if (code == "AW") country = "Aruba";
            if (code == "AU") country = "Australia";
            if (code == "AT") country = "Austria";
            if (code == "AZ") country = "Azerbaijan";
            if (code == "BS") country = "Bahamas the";
            if (code == "BH") country = "Bahrain";
            if (code == "BD") country = "Bangladesh";
            if (code == "BB") country = "Barbados";
            if (code == "BY") country = "Belarus";
            if (code == "BE") country = "Belgium";
            if (code == "BZ") country = "Belize";
            if (code == "BJ") country = "Benin";
            if (code == "BM") country = "Bermuda";
            if (code == "BT") country = "Bhutan";
            if (code == "BO") country = "Bolivia";
            if (code == "BA") country = "Bosnia";
            if (code == "BW") country = "Botswana";
            if (code == "BV") country = "Bouvet Island (Bouvetoya)";
            if (code == "BR") country = "Brazil";
            if (code == "IO") country = "British Indian Ocean Territory (Chagos Archipelago)";
            if (code == "VG") country = "British Virgin Islands";
            if (code == "BN") country = "Brunei Darussalam";
            if (code == "BG") country = "Bulgaria";
            if (code == "BF") country = "Burkina Faso";
            if (code == "BI") country = "Burundi";
            if (code == "KH") country = "Cambodia";
            if (code == "CM") country = "Cameroon";
            if (code == "CA") country = "Canada";
            if (code == "CV") country = "Cape Verde";
            if (code == "KY") country = "Cayman Islands";
            if (code == "CF") country = "Central African Republic";
            if (code == "TD") country = "Chad";
            if (code == "CL") country = "Chile";
            if (code == "CN") country = "China";
            if (code == "CX") country = "Christmas Island";
            if (code == "CC") country = "Cocos (Keeling) Islands";
            if (code == "CO") country = "Colombia";
            if (code == "KM") country = "Comoros the";
            if (code == "CD") country = "Congo";
            if (code == "CG") country = "Congo the";
            if (code == "CK") country = "Cook Islands";
            if (code == "CR") country = "Costa Rica";
            if (code == "CI") country = "Cote d\"Ivoire";
            if (code == "HR") country = "Croatia";
            if (code == "CU") country = "Cuba";
            if (code == "CY") country = "Cyprus";
            if (code == "CZ") country = "Czech Republic";
            if (code == "DK") country = "Denmark";
            if (code == "DJ") country = "Djibouti";
            if (code == "DM") country = "Dominica";
            if (code == "DO") country = "Dominican Republic";
            if (code == "EC") country = "Ecuador";
            if (code == "EG") country = "Egypt";
            if (code == "SV") country = "El Salvador";
            if (code == "GQ") country = "Equatorial Guinea";
            if (code == "ER") country = "Eritrea";
            if (code == "EE") country = "Estonia";
            if (code == "ET") country = "Ethiopia";
            if (code == "FO") country = "Faroe Islands";
            if (code == "FK") country = "Falkland Islands (Malvinas)";
            if (code == "FJ") country = "Fiji the Fiji Islands";
            if (code == "FI") country = "Finland";
            if (code == "FR") country = "France";
            if (code == "GF") country = "French Guiana";
            if (code == "PF") country = "French Polynesia";
            if (code == "TF") country = "French Southern Territories";
            if (code == "GA") country = "Gabon";
            if (code == "GM") country = "Gambia the";
            if (code == "GE") country = "Georgia";
            if (code == "DE") country = "Germany";
            if (code == "GH") country = "Ghana";
            if (code == "GI") country = "Gibraltar";
            if (code == "GR") country = "Greece";
            if (code == "GL") country = "Greenland";
            if (code == "GD") country = "Grenada";
            if (code == "GP") country = "Guadeloupe";
            if (code == "GU") country = "Guam";
            if (code == "GT") country = "Guatemala";
            if (code == "GG") country = "Guernsey";
            if (code == "GN") country = "Guinea";
            if (code == "GW") country = "Guinea-Bissau";
            if (code == "GY") country = "Guyana";
            if (code == "HT") country = "Haiti";
            if (code == "HN") country = "Honduras";
            if (code == "HK") country = "Hong Kong";
            if (code == "HU") country = "Hungary";
            if (code == "IS") country = "Iceland";
            if (code == "IN") country = "India";
            if (code == "ID") country = "Indonesia";
            if (code == "IR") country = "Iran";
            if (code == "IQ") country = "Iraq";
            if (code == "IE") country = "Ireland";
            if (code == "IM") country = "Isle of Man";
            if (code == "IL") country = "Israel";
            if (code == "IT") country = "Italy";
            if (code == "JM") country = "Jamaica";
            if (code == "JP") country = "Japan";
            if (code == "JE") country = "Jersey";
            if (code == "JO") country = "Jordan";
            if (code == "KZ") country = "Kazakhstan";
            if (code == "KE") country = "Kenya";
            if (code == "KI") country = "Kiribati";
            if (code == "KP") country = "Korea";
            if (code == "KR") country = "Korea";
            if (code == "KW") country = "Kuwait";
            if (code == "KG") country = "Kyrgyz Republic";
            if (code == "LA") country = "Lao";
            if (code == "LV") country = "Latvia";
            if (code == "LB") country = "Lebanon";
            if (code == "LS") country = "Lesotho";
            if (code == "LR") country = "Liberia";
            if (code == "LY") country = "Libyan Arab Jamahiriya";
            if (code == "LI") country = "Liechtenstein";
            if (code == "LT") country = "Lithuania";
            if (code == "LU") country = "Luxembourg";
            if (code == "MO") country = "Macao";
            if (code == "MK") country = "Macedonia";
            if (code == "MG") country = "Madagascar";
            if (code == "MW") country = "Malawi";
            if (code == "MY") country = "Malaysia";
            if (code == "MV") country = "Maldives";
            if (code == "ML") country = "Mali";
            if (code == "MT") country = "Malta";
            if (code == "MH") country = "Marshall Islands";
            if (code == "MQ") country = "Martinique";
            if (code == "MR") country = "Mauritania";
            if (code == "MU") country = "Mauritius";
            if (code == "YT") country = "Mayotte";
            if (code == "MX") country = "Mexico";
            if (code == "FM") country = "Micronesia";
            if (code == "MD") country = "Moldova";
            if (code == "MC") country = "Monaco";
            if (code == "MN") country = "Mongolia";
            if (code == "ME") country = "Montenegro";
            if (code == "MS") country = "Montserrat";
            if (code == "MA") country = "Morocco";
            if (code == "MZ") country = "Mozambique";
            if (code == "MM") country = "Myanmar";
            if (code == "NA") country = "Namibia";
            if (code == "NR") country = "Nauru";
            if (code == "NP") country = "Nepal";
            if (code == "NL") country = "Netherlands";
            if (code == "NC") country = "New Caledonia";
            if (code == "NZ") country = "New Zealand";
            if (code == "NI") country = "Nicaragua";
            if (code == "NE") country = "Niger";
            if (code == "NG") country = "Nigeria";
            if (code == "NU") country = "Niue";
            if (code == "NO") country = "Norway";
            if (code == "OM") country = "Oman";
            if (code == "PK") country = "Pakistan";
            if (code == "PW") country = "Palau";
            if (code == "PS") country = "Palestinian Territory";
            if (code == "PA") country = "Panama";
            if (code == "PG") country = "Papua New Guinea";
            if (code == "PY") country = "Paraguay";
            if (code == "PE") country = "Peru";
            if (code == "PH") country = "Philippines";
            if (code == "PN") country = "Pitcairn Islands";
            if (code == "PL") country = "Poland";
            if (code == "PT") country = "Portugal";
            if (code == "PR") country = "Puerto Rico";
            if (code == "QA") country = "Qatar";
            if (code == "RE") country = "Reunion";
            if (code == "RO") country = "Romania";
            if (code == "RU") country = "Russian Federation";
            if (code == "RW") country = "Rwanda";
            if (code == "BL") country = "Saint Barthelemy";
            if (code == "SH") country = "Saint Helena";
            if (code == "KN") country = "Saint Kitts and Nevis";
            if (code == "LC") country = "Saint Lucia";
            if (code == "MF") country = "Saint Martin";
            if (code == "WS") country = "Samoa";
            if (code == "SM") country = "San Marino";
            if (code == "ST") country = "Sao Tome and Principe";
            if (code == "SA") country = "Saudi Arabia";
            if (code == "SN") country = "Senegal";
            if (code == "RS") country = "Serbia";
            if (code == "SC") country = "Seychelles";
            if (code == "SL") country = "Sierra Leone";
            if (code == "SG") country = "Singapore";
            if (code == "SK") country = "Slovakia";
            if (code == "SI") country = "Slovenia";
            if (code == "SB") country = "Solomon Islands";
            if (code == "SO") country = "Somalia";
            if (code == "ZA") country = "South Africa";
            if (code == "ES") country = "Spain";
            if (code == "LK") country = "Sri Lanka";
            if (code == "SD") country = "Sudan";
            if (code == "SR") country = "Suriname";
            if (code == "SJ") country = "Svalbard & Jan Mayen Islands";
            if (code == "SZ") country = "Swaziland";
            if (code == "SE") country = "Sweden";
            if (code == "CH") country = "Switzerland";
            if (code == "SY") country = "Syrian Arab Republic";
            if (code == "TW") country = "Taiwan";
            if (code == "TJ") country = "Tajikistan";
            if (code == "TZ") country = "Tanzania";
            if (code == "TH") country = "Thailand";
            if (code == "TL") country = "Timor-Leste";
            if (code == "TG") country = "Togo";
            if (code == "TK") country = "Tokelau";
            if (code == "TO") country = "Tonga";
            if (code == "TT") country = "Trinidad and Tobago";
            if (code == "TN") country = "Tunisia";
            if (code == "TR") country = "Turkey";
            if (code == "TM") country = "Turkmenistan";
            if (code == "TC") country = "Turks and Caicos Islands";
            if (code == "TV") country = "Tuvalu";
            if (code == "UG") country = "Uganda";
            if (code == "UA") country = "Ukraine";
            if (code == "AE") country = "United Arab Emirates";
            if (code == "GB") country = "United Kingdom";
            if (code == "US") country = "USA";
            if (code == "UZ") country = "Uzbekistan";
            if (code == "VU") country = "Vanuatu";
            if (code == "VE") country = "Venezuela";
            if (code == "VN") country = "Vietnam";
            if (code == "WF") country = "Wallis and Futuna";
            if (code == "EH") country = "Western Sahara";
            if (code == "YE") country = "Yemen";
            if (code == "ZM") country = "Zambia";
            if (code == "ZW") country = "Zimbabwe";

            return country;
        }

        public Color UserColor(int colorIndex)
        {
            Color[] userColors = {
                Color.LightCoral,
                Color.LightSalmon,
                Color.LightPink,
                Color.PaleVioletRed,
                Color.Chocolate,
                Color.DarkKhaki,
                Color.Tomato,
                Color.Orange,
                Color.Gold,
                Color.SeaGreen,                
                Color.Plum,
                Color.LightGreen,
                Color.YellowGreen,
                Color.DarkSeaGreen,
                Color.Turquoise,
                Color.LightSteelBlue,
                Color.SkyBlue,
                Color.Tan,
                Color.SteelBlue,
                Color.Silver
            };

            return userColors[colorIndex];
        }
    }
}
