using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiline_App2020_Revised_2023
{
    class LoadPkgLabel
    {
        //public string getlocString(int vlocstring)
        //{
        //    string result = vlocstring.ToString();
        //    while (result.Length < 4)
        //    {
        //        result = "0" + result;
        //    }
        //    return result;
        //}

        //public int getnextlineloc(string str)
        //{
        //    int i;
        //    string testchar;
        //    int strlen;
        //    strlen = str.Length;
        //    int result;
        //    for (i = 0; i < strlen; i++)
        //    {
        //        testchar = str.Substring(strlen - i +1, 1);
        //        if (testchar == "" || testchar == "," || testchar == "/" || testchar == "-")
        //        {
        //            result = strlen - i + 1;
        //            return result;
        //        }
        //    }
        //    return 0;
        //}
        //public string LPL(string ItemID, string sizefield, string descfield, string QTY, string ponofield, string locfield, string opid, object labelprinter)
        //{
        //    string printdata = "";
        //    string labelHloc;
        //    string labelvloc;
        //    string printdate;
        //    string tempstr;
        //    int totalchars;

        //    string Size = "";
        //    string Desc = "";
        //    string pono = "";
        //    string loc = "";

        //    if (descfield != null)
        //    {
        //        Desc = descfield.Trim();
        //    }

        //    if (sizefield != null)
        //    {
        //        Size = sizefield.Trim();
        //    }

        //    if (ponofield != null)
        //    {
        //        pono = ponofield;
        //    }

        //    if (locfield != null)
        //    {
        //        loc = locfield.Trim();
        //    }

        //    int startsize = 0;
        //    int totalsize = 230;
        //    int alignvcenter = 4;

        //    printdate = DateTime.Now.ToString("MM/dd/yyyy");

        //    string fma;
        //    string fmb;
        //    string fmc;
        //    string fmd;
        //    string fmeee;
        //    string fmffff;
        //    string fmgggg;
        //    string fmhhhh;
        //    string fmiiii;

        //    int vloc;
        //    int hloc;
        //    fma = "1";
        //    fmb = "9";
        //    fmc = "1";
        //    fmd = "1";
        //    fmeee = "080";
        //    vloc = 183;
        //    hloc = 20;

            
        //    printdata = printdata + fma + fmb + fmc + fmd + fmeee + getlocString(vloc) + getlocString(hloc) + "PART NO:" + (char)13 + "FB+" + (char)13;

        //    vloc = 165;
        //    if (ItemID.Length <= 14)
        //    {
        //        totalchars = 14;
        //        hloc = 250 - labelprinter.GetLabelLoc(startsize, totalsize, totalsize / totalchars, ItemID.Length, alignvcenter);
        //        fmeee = "S00";
        //        fmhhhh = "P014";
        //        fmiiii = "P010";
        //    }
        //    else 
        //    {
        //        totalchars = ItemID.Trim().Length;
        //        hloc = 12 + ((19 - totalchars) * 5);
        //        fmeee = "S00";
        //        fmhhhh = "P014";
        //        fmiiii = "P010";
        //    }

        //    printdata = printdata + fma + fmb + fmc + fmd + fmeee + getlocString(vloc) + getlocString(hloc) + fmhhhh + fmiiii + ItemID + (char)13;

        //    totalchars = 14;
        //    vloc = 143;
        //    if (ItemID.Trim().Length <= 14)
        //    {
        //        hloc = 250 - labelprinter.GetLabelLoc(startsize, totalsize, totalsize / totalchars, ItemID.Length, alignvcenter);
        //    }
        //    else
        //    {
        //        totalchars = ItemID.Trim().Length;
        //        hloc = 12 + ((19 - totalchars) * 5);
        //    }

        //    printdata = printdata + "1e11020" + getlocString(vloc) + getlocString(hloc) + "A" + ItemID + (char)13;

        //    vloc = 136;
        //    hloc = 20;

        //    printdata = printdata + fma + fmb + fmc + fmd + "080" + getlocString(vloc) + getlocString(hloc) + "SIZE:" + (char)13;

        //    totalchars = 14;
        //    fmhhhh = "P012";

        //    if (Size.Length > 14)
        //    {
        //        if (Size.Length > 16)
        //        {
        //            totalchars = Size.Length;
        //            fmiiii = "P008";
        //        }
        //        else
        //        {
        //            totalchars = 16;
        //            fmiiii = "P010";
        //        }
        //    }
        //    else 
        //    {
        //        fmiiii = "P010";
        //    }

        //    vloc = 250 - 137;
        //    hloc = 250 - labelprinter.GetLabelLoc(-10, totalsize, totalsize / totalchars, Size.Length, alignvcenter);

        //    printdata = printdata + fma + fmb + fmc + fmd + fmeee + getlocString(vloc) + getlocString(hloc) + fmhhhh + fmiiii + Size + (char)13;

        //    vloc = 250 - 141;
        //    hloc = 40;
        //    printdata = printdata + "1X11" + "000" + getlocString(vloc) + getlocString(hloc) + "L190002" + (char)13;

        //    vloc = 105;
        //    hloc = 20;
        //    printdata = printdata + fma + fmb + fmc + fmd + "080" + getlocString(vloc) + getlocString(hloc) + "DESC:" + (char)13 + "FB-" + (char)13;

        //    totalchars = 18;
        //    fmhhhh = "P009";
        //    fmiiii = "P009";
        //    vloc = 250 - 164;

        //    int linebreakloc;
        //    while (Desc.Length > totalchars)
        //    {
        //        tempstr = Desc.Substring(0, totalchars);
        //        linebreakloc = getnextlineloc(tempstr);
        //        tempstr = Desc.Substring(0, linebreakloc).Trim();
        //        Desc = Desc.Substring(linebreakloc + 1).Trim();
        //        hloc = 250 - labelprinter.GetLabelLoc(16, totalsize, totalsize / totalchars, tempstr.Length, alignvcenter);
        //        if (tempstr.Length > 16)
        //        {
        //            hloc = 10;
        //        }
        //        printdata = printdata + fma + fmb + fmc + fmd + fmeee + getlocString(vloc) + getlocString(hloc) + fmhhhh + fmiiii + tempstr + (char)13;
        //        vloc = vloc - 22;
        //    }

        //    hloc = 250 + -labelprinter.GetLabelLoc(0, totalsize, totalsize / totalchars, Desc.Length, alignvcenter);
        //    printdata = printdata + fma + fmb + fmc + fmd + fmeee + getlocString(vloc) + getlocString(hloc) + fmhhhh + fmiiii + Desc + (char)13;



        //    vloc = 250 - 191;
        //    hloc = 40;
        //    printdata = printdata + "1X11" + "000" + getlocString(vloc) + getlocString(hloc) + "L190002" + (char)13;


        //    vloc = 57;
        //    hloc = 20;
        //    printdata = printdata + fma + fmb + fmc + fmd + "080" + getlocString(vloc) + getlocString(hloc) + "LOC:" + (char)13;


        //    vloc = 37;
        //    hloc = 27;
        //    printdata = printdata + fma + "911" + "013" + getlocString(vloc) + getlocString(hloc) + loc + (char)13;


        //    vloc = 37;
        //    hloc = 40;
        //    printdata = printdata + "1X11" + "000" + getlocString(vloc) + getlocString(hloc) + "L190002" + (char)13;


        //    vloc = 28;
        //    hloc = 20;
        //    printdata = printdata + fma + fmb + fmc + fmd + "080" + getlocString(vloc) + getlocString(hloc) + "QTY:" + (char)13;


        //    vloc = 10;
        //    hloc = 55;
        //    printdata = printdata + fma + "911" + "013" + getlocString(vloc) + getlocString(hloc) + QTY + (char)13;


        //    vloc = 15;
        //    hloc = 120;
        //    printdata = printdata + fma + "e11" + "020" + getlocString(vloc) + getlocString(hloc) + "A" + QTY + (char)13;


        //    vloc = 5;
        //    hloc = 30;
        //    printdata = printdata + fma + "911" + "080" + getlocString(vloc) + getlocString(hloc) + pono + (char)13;


        //    vloc = 49;
        //    hloc = 220;
        //    printdata = printdata + fma + "911" + "080" + getlocString(vloc) + getlocString(hloc) + opid + (char)13;


        //    vloc = 39;
        //    hloc = 185;
        //    printdata = printdata + fma + "911" + "080" + getlocString(vloc) + getlocString(hloc) + printdate + (char)13;
        //    return printdata;
        //}
    }
}
