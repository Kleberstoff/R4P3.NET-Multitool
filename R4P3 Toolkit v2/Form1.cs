using MaterialSkin;
using MaterialSkin.Controls;

using Microsoft.Win32;

using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;

namespace R4P3_Toolkit_v2
{
    /*
    NAME EXPLOIT
    
    self.add() posted 'original' array's:
    const char search[] = { 'A', 'A', 'B', 'B', 'C', 'E', 'E', 'H', 'H', 'I', 'I', 'J', 'K', 'K', 'M', 'M', 'N', 'O', 'O', 'P', 'Q', 'S', 'T', 'T', 'X', 'X', 'Y', 'Y', 'Z', 'a', 'c', 'd', 'e', 'h', 'i', 'j', 'o', 'o', 'p', 'q', 's', 'w', 'x', 'y', 'z' ,' '}
    const char replace[] = { 'Α', 'А', 'Β', 'В', 'С', 'Ε', 'Е', 'Η', 'Н', 'Ι', 'І', 'Ј', 'Κ', 'К', 'Μ', 'М', 'Ν', 'Ο', 'О', 'Р', 'Ԛ', 'Ѕ', 'Τ', 'Т', 'Χ', 'Х', 'Υ', 'Ү', 'Ζ', 'а', 'с', 'ԁ', 'е', 'һ', 'і', 'ј', 'ο', 'о', 'р', 'ԛ', 'ѕ', 'ᴡ', 'х', 'у', 'ᴢ', ' '}
    
    Thanks to "self.add()" for providing those Letters, without him I wouldn't be 'updating' iJoris's Version.    
    self.add(): https://r4p3.net/members/self-add.258/
    iJoris: https://r4p3.net/members/ijoris.102/
    iJoris's Thread: https://r4p3.net/threads/name-exploit.76/ | VIP Release, hopefully releasing this also for Non-VIP's.

    Also Thanks to "invisiblemagic" for providing the 0px(Pixel) wide Character.
    ⁢⁢⁢invisiblemagic: https://r4p3.net/members/invisiblemagic.470/
    invisiblemagic's thread: https://r4p3.net/threads/new-string-for-no-name-also-works-on-steam.601/

    Also shoutouts too 0day for making a similar programm.
    0day: https://r4p3.net/members/0day.2219/
    oday's Thread:https://r4p3.net/threads/steal-any-name.604/

    EXTRACTOR

    Ridicc/basiK's R4P3 Extractor gave me the Idea
    Ridicc/basiK: https://r4p3.net/members/ridicc.252/
    Ridicc/basiK's Thread: https://r4p3.net/threads/r4p3-extractor.1645/

    Crack Checker
    
    Supervisor's Crackchecker for Code and Idea
    Supervisor: https://r4p3.net/members/supervisor.10/
    Supervisor's Thread: https://r4p3.net/threads/crack-checker.838/
    */
    public partial class Form1 : MaterialForm
    {
        /* //============ VARIABLES ============\\ */

        /* //=== ARRAY FOR SEARCHING AND REPLACING ===\\ */
        char[] search = { 'A', 'B', 'C', 'E', 'H', 'I', 'J', 'K', 'M', 'N', 'O', 'P', 'Q', 'S', 'T', 'X', 'Y', 'Z', 'a', 'c', 'd', 'e', 'h', 'i', 'j', 'o', 'p', 'q', 's', 'w', 'x', 'y', 'z', ' ' };
        char[] replace = { 'Α', 'Β', 'С', 'Ε', 'Η', 'І', 'Ј', 'Κ', 'М', 'Ν', 'Ο', 'Р', 'Ԛ', 'Ѕ', 'Τ', 'Χ', 'Υ', 'Ζ', 'а', 'с', 'ԁ', 'е', 'һ', 'і', 'ј', 'ο', 'р', 'ԛ', 'ѕ', 'ᴡ', 'х', 'у', 'ᴢ', ' ' };
        /* \\=== ARRAY FOR SEARCHING AND REPLACING ===// */

        /* //=== INVISIBLE MAGIC ===\\ */
        string InvisibleMagic = "⁢";
        /* \\=== INVISIBLE MAGIC ===// */

        /* //=== IGNORE DIRECTORIES EXTRACTOR ===\\ */
        string DefautlIgnoreArray = "remote,qtwebengine_persistant_storage,qtwebengine_cache,badges";
        /* \\=== IGNORE DIRECTORIES EXTRACTOR ===// */

        /* //=== THEME CHANGER ===\\ */
        private readonly MaterialSkinManager materialSkinManager;
        /* \\=== THEME CHANGER ===// */

        /* //=== SETTINGS SHORTCUTS ===\\ */
        bool DefaultWhite = Properties.Settings.Default.DefaultWhite;
        string ignoreArrayString = Properties.Settings.Default.ignoreArray;
        string SaveLocation = Properties.Settings.Default.DefaultSaveLocation;
        string CacheFolder = Properties.Settings.Default.CacheFolder;
        /* \\=== SETTINGS SHORTCUTS ===// */

        bool getAvatar = false;

        /* //============ VARIABLES ============\\ */

        public Form1()
        {
            InitializeComponent();
            //default stuff
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            if (DefaultWhite == true)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                listBox1.BackColor = Color.FromArgb(51, 51, 51);
                listBox1.ForeColor = Color.White;
                listBox2.BackColor = Color.FromArgb(51, 51, 51);
                listBox2.ForeColor = Color.White;
            }
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            //skin stuff
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //On Form Load
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://r4p3.net/";
            linkLabel1.Links.Add(link);
            linkLabel2.Links.Add(link);
            linkLabel3.Links.Add(link);
            linkLabel4.Links.Add(link);
            linkLabel5.Links.Add(link);
            //LinkLabel Links

            materialSingleLineTextField5.Text = SaveLocation;
            if (Directory.Exists(CacheFolder) && CacheFolder != null && CacheFolder != "")
            {
                await UpdateignoreArray(ignoreArrayString);
            }
            else
            {
                getTeamsSpeakFolder();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ignoreArray = materialSingleLineTextField4.Text;
            Properties.Settings.Default.DefaultSaveLocation = materialSingleLineTextField5.Text;
            Properties.Settings.Default.Save();
        }

        /* //=== NAME EXPLOITER ===\\ */
        private void materialFlatButton7_Click(object sender, EventArgs e)
        {
            //exploit button
            string nameToExploit = materialSingleLineTextField1.Text;
            string exploitedName = nameToExploit;

            if(nameToExploit == "" || nameToExploit == "to Exploit")
            {
                //Nothing entered, or default text - yell at user.
                MessageBox.Show("Please enter a Name to exploit.","Nothing to Exploit!.");
                return;
            }
            else
            {
                //something entered, don't yell at user and exploit da shiz
                char[] CharArrayToExploit = nameToExploit.ToCharArray();
                int i = 0;
                foreach(char LetterToExploit in search)
                {
                    if(CharArrayToExploit.Contains(LetterToExploit))
                    {
                        exploitedName = exploitedName.Replace(LetterToExploit, replace[i]);
                    }
                    i++;
                }
                materialSingleLineTextField2.ResetText();
                materialSingleLineTextField2.Text = exploitedName;

                materialSingleLineTextField3.ResetText();
                materialSingleLineTextField3.Text = exploitedName + InvisibleMagic;
            }
        }

        private void materialFlatButton9_Click(object sender, EventArgs e)
        {
            //copy to clipboard without invisble magic
            if (materialSingleLineTextField2.Text != "" || materialSingleLineTextField2.Text != "Username w/ invisble Magic")
            {
                Clipboard.Clear();
                Clipboard.SetText(materialSingleLineTextField2.Text);
            }
        }

        private void materialFlatButton8_Click(object sender, EventArgs e)
        {
            //copy to cliboard with invisble magic
            if(materialSingleLineTextField3.Text != "" || materialSingleLineTextField3.Text != "Username w/ invisble Magic")
            {
                Clipboard.Clear();
                Clipboard.SetText(materialSingleLineTextField3.Text);
            }
        }
        /* \\=== NAME EXPLOITER ===// */

        /* //=== EXTRACTOR ===\\ */
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            listBox1.SelectedIndex = index;
        }

        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            int index = listBox2.IndexFromPoint(e.Location);
            listBox2.SelectedIndex = index;
        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                if (pictureBox1.Image != null)
                {
                    materialLabel22.ForeColor = Color.Red;
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                string serverDirectory = CacheFolder + "\\" + listBox1.SelectedItem + "\\";
                string iconDirectory = serverDirectory + "icons\\";
                string avatarDirectory = serverDirectory + "clients\\";

                if (getAvatar == false)
                {
                    await getIcons(iconDirectory);
                }
                else
                {
                    await getAvatars(avatarDirectory);
                }
            }
        }

        private async void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null && listBox2.SelectedItem.ToString() != "Folder not Found")
            {
                await makePreview(listBox1.SelectedItem.ToString(), listBox2.SelectedItem.ToString());
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open Folder
            Process.Start(CacheFolder + "\\" + listBox1.SelectedItem);
        }

        private async void copyFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //copy folder
            if (SaveLocation != "Prompt")
            {
                await DirectoryCopy(CacheFolder + "\\" + listBox1.SelectedItem, SaveLocation, listBox1.SelectedItem.ToString());
            }
            else
            {
                var folder = new FolderBrowserDialog();
                DialogResult result = folder.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                {
                    await DirectoryCopy(CacheFolder + "\\" + listBox1.SelectedItem, folder.SelectedPath, listBox1.SelectedItem.ToString());
                }
            }
        }

        private async void copyFolderAsZIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //copy as zip
            if (SaveLocation != "Prompt")
            {
                await DirectoryZIP(CacheFolder + "\\" + listBox1.SelectedItem, SaveLocation, listBox1.SelectedItem.ToString());
            }
            else
            {
                var folder = new FolderBrowserDialog();
                DialogResult result = folder.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                {
                    await DirectoryZIP(CacheFolder + "\\" + listBox1.SelectedItem, folder.SelectedPath, listBox1.SelectedItem.ToString());
                }
            }
        }

        private async void materialFlatButton4_Click(object sender, EventArgs e)
        {
            string serverDirectory = CacheFolder + "\\" + listBox1.SelectedItem + "\\";
            string iconDirectory = serverDirectory + "icons\\";
            string avatarDirectory = serverDirectory + "clients\\";

            if(pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            if (getAvatar == true)
            {
                materialLabel5.Text = "Icons";
                materialFlatButton4.Text = "Switch to Avatars";
                await getIcons(iconDirectory);
                getAvatar = false;
            }
            else
            {
                materialLabel5.Text = "Avatars";
                materialFlatButton4.Text = "Switch to Icons";
                await getAvatars(avatarDirectory);
                getAvatar = true;
            }
        }

        private void openFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (materialLabel5.Text == "Icons")
            {
                Process.Start(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons" );
            }
            else
            {
                Process.Start(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients");
            }
        }

        private async void copyFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(SaveLocation != "Prompt")
            {
                if (materialLabel5.Text == "Icons")
                {
                    await DirectoryCopy(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons", SaveLocation, listBox1.SelectedItem.ToString() + " - Icons");
                }
                else
                {
                    await DirectoryCopy(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients", SaveLocation, listBox1.SelectedItem.ToString() + " - Avatar");
                }
            }
            else
            {
                var folder = new FolderBrowserDialog();
                DialogResult result = folder.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                {
                    if (materialLabel5.Text == "Icons")
                    {
                        await DirectoryCopy(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons", folder.SelectedPath, listBox1.SelectedItem.ToString() + " - Icons");
                    }
                    else
                    {
                        await DirectoryCopy(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients", folder.SelectedPath, listBox1.SelectedItem.ToString() + " - Avatar");
                    }
                }
            }
        }

        private async void copyFolderAsZIPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(SaveLocation != "Prompt")
            {
                if (materialLabel5.Text == "Icons")
                {
                    await DirectoryZIP(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons", SaveLocation, listBox1.SelectedItem.ToString() + " - Icons");
                }
                else
                {
                    await DirectoryZIP(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients", SaveLocation, listBox1.SelectedItem.ToString() + " - Avatar");
                }
            }
            else
            {
                var folder = new FolderBrowserDialog();
                DialogResult result = folder.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                {
                    if (materialLabel5.Text == "Icons")
                    {
                        await DirectoryZIP(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons", folder.SelectedPath, listBox1.SelectedItem.ToString() + " - Icons");
                    }
                    else
                    {
                        await DirectoryZIP(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients", folder.SelectedPath, listBox1.SelectedItem.ToString() + " - Icons");
                    }
                }
            }
        }

        private async void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (SaveLocation != "Prompt")
                {
                    if (materialFlatButton4.Text == "Switch to Avatars")
                    {
                        await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons\\" + listBox2.SelectedItem, SaveLocation, false, false, false, listBox2.SelectedItem.ToString());
                    }
                    else
                    {
                        await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients\\" + listBox2.SelectedItem, SaveLocation, false, false, false, listBox2.SelectedItem.ToString());
                    }
                }
                else
                {
                    var folder = new FolderBrowserDialog();
                    DialogResult result = folder.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                    {
                        if (materialFlatButton4.Text == "Switch to Avatars")
                        {
                            await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons\\" + listBox2.SelectedItem, folder.SelectedPath, false, false, false, listBox2.SelectedItem.ToString());
                        }
                        else
                        {
                            await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients\\" + listBox2.SelectedItem, folder.SelectedPath, false, false, false, listBox2.SelectedItem.ToString());
                        }
                    }
                }
            }
        }

        private async void saveImageAsPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (SaveLocation != "Prompt")
                {
                    if (materialFlatButton4.Text == "Switch to Avatars")
                    {
                        await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons\\" + listBox2.SelectedItem, SaveLocation, false, true, false, listBox2.SelectedItem.ToString());
                    }
                    else
                    {
                        await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients\\" + listBox2.SelectedItem, SaveLocation, false, true, false, listBox2.SelectedItem.ToString());
                    }
                }
                else
                {
                    var folder = new FolderBrowserDialog();
                    DialogResult result = folder.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                    {
                        if (materialFlatButton4.Text == "Switch to Avatars")
                        {
                            await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons\\" + listBox2.SelectedItem, folder.SelectedPath, false, true, false, listBox2.SelectedItem.ToString());
                        }
                        else
                        {
                            await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients\\" + listBox2.SelectedItem, folder.SelectedPath, false, true, false, listBox2.SelectedItem.ToString());
                        }
                    }
                }
            }
        }

        private async void saveImageAsJPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (SaveLocation != "Prompt")
                {
                    if (materialFlatButton4.Text == "Switch to Avatars")
                    {
                        await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons\\" + listBox2.SelectedItem, SaveLocation, false, false, true, listBox2.SelectedItem.ToString());
                    }
                    else
                    {
                        await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients\\" + listBox2.SelectedItem, SaveLocation, false, false, true, listBox2.SelectedItem.ToString());
                    }
                }
                else
                {
                    var folder = new FolderBrowserDialog();
                    DialogResult result = folder.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                    {
                        if (materialFlatButton4.Text == "Switch to Avatars")
                        {
                            await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons\\" + listBox2.SelectedItem, folder.SelectedPath, false, false, true, listBox2.SelectedItem.ToString());
                        }
                        else
                        {
                            await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients\\" + listBox2.SelectedItem, folder.SelectedPath, false, false, true, listBox2.SelectedItem.ToString());
                        }
                    }
                }
            }
        }

        private async void saveImageAsGIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (SaveLocation != "Prompt")
                {
                    if (materialFlatButton4.Text == "Switch to Avatars")
                    {
                        await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons\\" + listBox2.SelectedItem, SaveLocation, true, false, false, listBox2.SelectedItem.ToString());
                    }
                    else
                    {
                        await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients\\" + listBox2.SelectedItem, SaveLocation, true, false, false, listBox2.SelectedItem.ToString());
                    }
                }
                else
                {
                    var folder = new FolderBrowserDialog();
                    DialogResult result = folder.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                    {
                        if (materialFlatButton4.Text == "Switch to Avatars")
                        {
                            await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\icons\\" + listBox2.SelectedItem, folder.SelectedPath, true, false, false, listBox2.SelectedItem.ToString());
                        }
                        else
                        {
                            await saveImage(CacheFolder + "\\" + listBox1.SelectedItem + "\\clients\\" + listBox2.SelectedItem, folder.SelectedPath, true, false, false, listBox2.SelectedItem.ToString());
                        }
                    }
                }
            }
        }
        /* \\=== EXTRACTOR ===// */

        /* //=== CRACK CHECKER ===\\ */
        private async void materialFlatButton10_Click(object sender, EventArgs e)
        {
            //check button
            
            string[] IP = materialSingleLineTextField6.Text.Split(',');
            materialFlatButton10.Enabled = false;
            Task CrackCheck = Task.Run(async () => await CrackChecker(IP));
            await StatusUpdater(CrackCheck);
        }
        /* \\=== CRACK CHECKER ===// */

        /* //=== OPTIONS ===\\ */
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            //Change Theme button
            if(materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                listBox1.BackColor = Color.FromArgb(51, 51, 51);
                listBox1.ForeColor = Color.White;
                listBox2.BackColor = Color.FromArgb(51, 51, 51);
                listBox2.ForeColor = Color.White;
                Properties.Settings.Default.DefaultWhite = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                if(materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
                {
                    materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    listBox1.ResetBackColor();
                    listBox1.ResetForeColor();
                    listBox2.ResetBackColor();
                    listBox2.ResetForeColor();
                    Properties.Settings.Default.DefaultWhite = true;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private async void materialFlatButton2_Click(object sender, EventArgs e)
        {
            //Update ignore List
            await UpdateignoreArray(materialSingleLineTextField4.Text);
        }

        private async void materialFlatButton3_Click(object sender, EventArgs e)
        {
            //reset ignore list
            await UpdateignoreArray(DefautlIgnoreArray);
        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            var folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
            {
                Properties.Settings.Default.DefaultSaveLocation = folder.SelectedPath;
                materialSingleLineTextField5.Text = folder.SelectedPath;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }

            SaveLocation = Properties.Settings.Default.DefaultSaveLocation;
        }

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultSaveLocation = "Prompt";
            materialSingleLineTextField5.Text = "Prompt";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            SaveLocation = "Prompt";
        }
        /* \\=== OPTIONS ===// */

        /* //=== FUNCTIONS ===\\ */
        private async void getTeamsSpeakFolder()
        {
            try
            {
                string Appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TS3Client\\cache";

                if(Directory.Exists(Appdata))
                {
                    CacheFolder = Appdata;
                    Properties.Settings.Default.CacheFolder = Appdata;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    await UpdateignoreArray(ignoreArrayString);
                    return;
                }

                RegistryKey rk64x = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
                rk64x = rk64x.OpenSubKey("Software\\TeamSpeak 3 Client", false);
                if (rk64x != null)
                {
                    string Folder64x = rk64x.GetValue(null).ToString() + "\\config\\cache";
                    if (Directory.Exists(Folder64x))
                    {
                        CacheFolder = Folder64x;
                        Properties.Settings.Default.CacheFolder = Folder64x;
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();

                        await UpdateignoreArray(ignoreArrayString);
                        return;
                    }
                }
                RegistryKey rk86x = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
                rk86x = rk86x.OpenSubKey("Software\\Wow6432Node\\TeamSpeak 3 Client", false);
                if(rk86x != null)
                {
                    string Folder86x = rk86x.GetValue(null).ToString() + "\\config\\cache";
                    if(Directory.Exists(Folder86x))
                    {
                        CacheFolder = Folder86x;
                        Properties.Settings.Default.CacheFolder = Folder86x;
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();

                        await UpdateignoreArray(ignoreArrayString);
                        return;
                    }
                }
                else
                {
                    //fuck, ehm, ehm, FUCK, welp
                    MessageBox.Show("Couldn't get TeamSpeak 3 Client Folder, please select Manually.");
                    var folder = new FolderBrowserDialog();
                    DialogResult result = folder.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                    {
                        if (Directory.Exists(folder.SelectedPath + "\\config\\cache"))
                        {
                            CacheFolder = folder.SelectedPath + "\\config\\cache";
                            Properties.Settings.Default.CacheFolder = folder.SelectedPath + "\\config\\cache";
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();

                            await UpdateignoreArray(ignoreArrayString);
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task getFolders(string[] ignore)
        {
            //Get Server Folders 
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                Directory.SetCurrentDirectory(CacheFolder);
                string[] Folders = Directory.GetDirectories(Directory.GetCurrentDirectory());

                if(listBox1.Items.Count != 0)
                {
                    listBox1.Items.Clear();
                }

                foreach (string Folder in Folders)
                {
                    if (!ignore.Any(Folder.Contains))
                    {
                        listBox1.Items.Add(Folder.Replace(CacheFolder + "\\", ""));
                    }
                    await Task.Delay(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong! :(");
            }
        }

        private async Task CrackChecker(string[] IPAddress)
        {
            foreach(string IP in IPAddress)
            {
                try
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(IP);
                    if (hostEntry.AddressList.Length != 0)
                    {
                        string CheckToIP = Convert.ToString(hostEntry.AddressList[0]);
                        TcpClient client = new TcpClient();
                        await client.ConnectAsync(CheckToIP, 2008);
                        MessageBox.Show(CheckToIP + " seems to be Cracked.", "Cracked?");
                    }
                }
                catch
                {
                    MessageBox.Show(IP + " doesn't seem to be Cracked.","not Cracked?");
                }
            }
        }

        private async Task StatusUpdater(Task CheckTask)
        {
            while (true)
            {
                if (!CheckTask.IsCompleted)
                {
                    materialLabel10.Text = "Running";
                    await Task.Delay(1);
                }
                else
                {
                    materialLabel10.Text = "Done";
                    materialFlatButton10.Enabled = true;
                    return;
                }
            }
        }

        private async Task DirectoryCopy(string path, string targetPath, string folderName)
        {
            try
            {
                targetPath = targetPath + "\\" +folderName;
                DirectoryInfo dir = new DirectoryInfo(path);
                DirectoryInfo[] dirs = dir.GetDirectories();

                if (!Directory.Exists(path))
                {
                    MessageBox.Show("Folder to Copy doesn't' exists. :C", "Something went wrong!");
                    return;
                }
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(targetPath, file.Name);
                    file.CopyTo(temppath, false);
                }
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(targetPath, subdir.Name);
                    await DirectoryCopy(subdir.FullName, temppath, null);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ":c");
            }
        }

        private async Task DirectoryZIP(string path, string targetPath, string zipName)
        {
            targetPath = targetPath + "\\"+zipName+".zip";
            try
            {
                ZipFile.CreateFromDirectory(path, targetPath);
                await Task.Delay(1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ":C");
            }
        }

        private async Task UpdateignoreArray(string IgnoreString)
        {
            if (IgnoreString != "<Default Ignored Folders>")
            {
                Properties.Settings.Default.ignoreArray = materialSingleLineTextField4.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                materialSingleLineTextField4.Text = IgnoreString.ToString();
                string[] UpdatedignoreArray = IgnoreString.Split(',');
                await getFolders(UpdatedignoreArray);
                return;
            }
        }

        private async Task getIcons(string path)
        {
            try
            {
                if (listBox2.Items.Count != 0)
                {
                    listBox2.Items.Clear();
                }

                DirectoryInfo directory = new DirectoryInfo(path);
                FileInfo[] files = directory.GetFiles();

                foreach (FileInfo file in files)
                {
                    if (file.Name != "dummy.png")
                    {
                        listBox2.Items.Add(file.Name);
                        await Task.Delay(0);
                    }
                }
            }
            catch
            {
            }
        }

        private async Task getAvatars(string path)
        {
            try
            {
                if (listBox2.Items.Count != 0)
                {
                    listBox2.Items.Clear();
                }

                DirectoryInfo directory = new DirectoryInfo(path);
                FileInfo[] files = directory.GetFiles();

                foreach (FileInfo file in files)
                {
                    listBox2.Items.Add(file.Name);
                    await Task.Delay(0);
                }
            }
            catch
            {
                listBox2.Items.Add("Folder not found.");
            }
        }

        private async Task makePreview(string server, string image)
        {
            try
            {
                string serverDirectory = CacheFolder + "\\" + server + "\\";
                if (materialFlatButton4.Text == "Switch to Avatars")
                {
                    if(Image.FromFile(serverDirectory + "icons\\" + image) != null)
                    {
                        Image.FromFile(serverDirectory + "icons\\" + image).Dispose();
                    }
                    Image previewImage = Image.FromFile(serverDirectory + "icons\\" + image);
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    await setPreview(previewImage);
                }
                else
                {
                    if (Image.FromFile(serverDirectory + "clients\\" + image) != null)
                    {
                        Image.FromFile(serverDirectory + "clients\\" + image).Dispose();
                    }
                    Image previewImage = Image.FromFile(serverDirectory + "clients\\" + image);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    await setPreview(previewImage);
                }
            }
            catch(OutOfMemoryException)
            {
                // Meaning the Picture is not a image, corrupted or something 
            }
        }

        private async Task setPreview(Image image)
        {
            pictureBox1.Image = image;
            await Task.Delay(0);
        }

        private async Task saveImage(string path, string targetPath, bool gif, bool png, bool jpg, string ImageName)
        {
            try
            {
                
                if (gif == true && png == false && jpg == false)
                {
                    targetPath = targetPath + "\\" + ImageName + ".gif";
                    FileInfo file = new FileInfo(path);
                    file.CopyTo(targetPath);
                    await Task.Delay(1);
                    return;
                }

                if (gif == false && png == true && jpg == false)
                {
                    targetPath = targetPath + "\\" + ImageName + ".png";
                    FileInfo file = new FileInfo(path);
                    file.CopyTo(targetPath);
                    await Task.Delay(1);
                    return;
                }

                if (gif == false && png == false && jpg == true)
                {
                    targetPath = targetPath + "\\" + ImageName + ".jpg";
                    FileInfo file = new FileInfo(path);
                    file.CopyTo(targetPath);
                    await Task.Delay(1);
                    return;
                }
                else
                {
                    targetPath = targetPath + "\\" + ImageName;
                    FileInfo file = new FileInfo(path);
                    file.CopyTo(targetPath);
                    await Task.Delay(1);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
        }

        private void LinkLabel_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string); //opens r4p3.net in the webbrowser
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        /* \\=== FUNCTIONS ===// */
    }
}