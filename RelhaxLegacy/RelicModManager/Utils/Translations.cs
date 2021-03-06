using System;
using System.Collections;

namespace RelhaxModpack
{
    //A static class to exist throughout the entire application life, will always have translations
    public static class Translations
    {
        //Enumerator to determine which translated string to return
        public enum Languages { English = 0, German = 1, Polish = 2, French = 3, Russian = 4 };
        public static Languages language = Languages.English;//set it to this default
        public static Hashtable english = new Hashtable();
        public static Hashtable german = new Hashtable();
        public static Hashtable polish = new Hashtable();
        public static Hashtable french = new Hashtable();
        public static Hashtable russian = new Hashtable();
        public const string TranslationNeeded = "TODO";
        //load hashes on application startup

        public static string GetTranslatedString(string componetName)
        {
            return GetTranslatedString(componetName, language);
        }

        private static string GetTranslatedString(string componetName, Languages lang)
        {
            try
            {
                string s = "";
                switch (lang)
                {
                    case (Languages.English):
                        if (english.Contains(componetName))
                        {
                            return (string)"" + english[componetName];
                        }
                        break;
                    case (Languages.German):
                        if (german.Contains(componetName))
                        {
                            s = (string)"" + german[componetName];
                            if (s.ToUpper().Equals(TranslationNeeded))
                            {
                                Logging.Manager(string.Format("WARNING: german translation for \"{0}\" is missing.", componetName));
                                s = (string)"" + english[componetName];
                            }
                            return s;
                        }
                        break;
                    case (Languages.Polish):
                        if (polish.Contains(componetName))
                        {
                            s = (string)polish[componetName];
                            if (s.ToUpper().Equals(TranslationNeeded))
                            {
                                Logging.Manager(string.Format("WARNING: polish translation for \"{0}\" is missing.", componetName));
                                s = (string)english[componetName];
                            }
                            return s;
                        }
                        break;
                    case (Languages.French):
                        if (french.Contains(componetName))
                        {
                            s = (string)french[componetName];
                            if (s.ToUpper().Equals(TranslationNeeded))
                            {
                                Logging.Manager(string.Format("WARNING: french translation for \"{0}\" is missing.", componetName));
                                s = (string)english[componetName];
                            }
                            return s;
                        }
                        break;
                    case Languages.Russian:
                        if(russian.Contains(componetName))
                        {
                            s = (string)russian[componetName];
                            if (s.ToUpper().Equals(TranslationNeeded))
                            {
                                Logging.Manager(string.Format("WARNING: russian translation for \"{0}\" is missing.", componetName));
                                s = (string)english[componetName];
                            }
                            return s;
                        }
                        break;
                }
                Logging.Manager(string.Format("ERROR: no value in language hash for key: {0}  Language: {1}", componetName, lang));
                return componetName;
            }
            catch (Exception ex)
            {
                Utils.ExceptionLog("getTranslatedString", string.Format("key: \"{0}\"  Language: english", componetName), ex);
                return componetName;
            }

        }
        //add a mesage to all languages
        private static void AddToAll(string key, string message)
        {
            english.Add(key,message);
            german.Add(key, message);
            polish.Add(key, message);
            french.Add(key, message);
            russian.Add(key, message);
        }
        //method to load each translated string based on which language is selected
        public static void LoadHashes()
        {
            //Syntax is as follows:
            //languageName.Add("componetName","TranslatedString");

            #region General expressions
            english.Add("yes", "yes");
            german.Add("yes", "ja");
            polish.Add("yes", "Tak");
            french.Add("yes", "Oui");
            russian.Add("yes", "Да");

            english.Add("no", "no");
            german.Add("no", "nein");
            polish.Add("no", "Nie");
            french.Add("no", "Non");
            russian.Add("no", "Нет");

            english.Add("cancel", "Cancel");
            german.Add("cancel", "Abbrechen");
            polish.Add("cancel", "Anuluj");
            french.Add("cancel", "Anuler");
            russian.Add("cancel", "Отмена");

            english.Add("delete", "Delete");
            german.Add("delete", "Löschen");
            polish.Add("delete", TranslationNeeded);
            french.Add("delete", TranslationNeeded);
            russian.Add("delete", "Удалить");

            english.Add("warning", "WARNING");
            german.Add("warning", "WARNUNG");
            polish.Add("warning", "OSTRZEŻENIE");
            french.Add("warning", "ATTENTION");
            russian.Add("warning", "ВНИМАНИЕ");

            english.Add("critical", "CRITICAL");
            german.Add("critical", "KRITISCH");
            polish.Add("critical", "BŁĄD KRYTYCZNY");
            french.Add("critical", "CRITIQUAL");
            russian.Add("critical", "КРИТИЧЕСКАЯ ОШИБКА");

            english.Add("information", "Information");
            german.Add("information", "Information");
            polish.Add("information", "Informacja");
            french.Add("information", "information");
            russian.Add("information", "Информация");

            english.Add("select", "Select");
            german.Add("select", "Auswählen");
            polish.Add("select", "Wybierz");
            french.Add("select", "Sélectionner");
            russian.Add("select", "Выбрать");

            english.Add("abort", "Abort");
            german.Add("abort", "Abbrechen");
            polish.Add("abort", "Anulować");
            french.Add("abort", "Annuler");
            russian.Add("abort", "Отменить");

            english.Add("error", "Error");
            german.Add("error", "Fehler");
            polish.Add("error", "Błąd");
            french.Add("error", "Erreur");
            russian.Add("error", "Ошибка");

            english.Add("retry", "Retry");
            german.Add("retry", "Wiederholen");
            polish.Add("retry", "Spróbować ponownie");
            french.Add("retry", "Reaissayer");
            russian.Add("retry", "Повторить");

            english.Add("ignore", "Ignore");
            german.Add("ignore", "Ignorieren");
            polish.Add("ignore", "Ignorować");
            french.Add("ignore", "Ignorer");
            russian.Add("ignore", "Игнорировать");

            english.Add("lastUpdated", "Last Updated: ");
            german.Add("lastUpdated", "Letzte Aktualisierung: ");
            polish.Add("lastUpdated", "Ostatnio Zaktualizowano: ");
            french.Add("lastUpdated", "Dernière mise à jour: ");
            russian.Add("lastUpdated", "Последнее обновление: ");

            english.Add("stepsComplete", "tasks completed");
            german.Add("stepsComplete", "erledigte Aufgaben");
            polish.Add("stepsComplete", "zadania zakończone");
            french.Add("stepsComplete", "tâches terminées");
            russian.Add("stepsComplete", "заданий выполнено");

            english.Add("stop", "Stop");
            german.Add("stop", "Stop");
            polish.Add("stop", "Przerwać");
            french.Add("stop", "Arrêter");
            russian.Add("stop", "Остановить");

            english.Add("playPause", "Play/Pause");
            german.Add("playPause", "Play/Pause");
            polish.Add("playPause", "Odtwórz/wstrzymaj");
            french.Add("playPause", "Jouer/Pauser");
            russian.Add("playPause", "Воспр./Пауза");
            #endregion

            #region General Messages
            english.Add("conflictBetaDBTestMode", "The command line options '/BetaDatabase' and '/Test' should not be used together, the application may be unstable. Continue anyway?");
            german.Add("conflictBetaDBTestMode", "Die Kommandozeilen Befehle '/BetaDatabase' und '/Test' sollten nicht zusammen verwendet werden, da sonst der ModPack Manager instabil werden könnte. Trotzdem fortfahren?");
            polish.Add("conflictBetaDBTestMode", "Opcje Beta wiersza poleceń dotyczące Bazy Danych i Testu nie powinny być używane jednocześnie, aplikacja może nie być stabilna. Czy kontynuować mimo wszystko?");
            french.Add("conflictBetaDBTestMode", "Les options de ligne de commande '/BetaDatabase' et '/Test' ne doivent pas être utilisées ensemble, l'application peut être instable. Continuer quand même?");
            russian.Add("conflictBetaDBTestMode", "Параметры командной строки '/BetaDatabase' и '/Test' не должны использоваться одновременно, приложение может работать нестабильно. Продолжить в любом случае?");

            english.Add("conflictsCommandlineHeader", "Command-Line option conflicts");
            german.Add("conflictsCommandlineHeader", "Konflikte in den Kommandozeilen Befehlen");
            polish.Add("conflictsCommandlineHeader", "Konflikt opcji wiersza poleceń.");
            french.Add("conflictsCommandlineHeader", "Conflits d'options de ligne de commande");
            russian.Add("conflictsCommandlineHeader", "Конфликтующие параметры командной строки");
            #endregion

            #region BackgroundForum
            //Component: MenuItemRestore
            //The menu item for restoring the application
            english.Add("MenuItemRestore", "Restore");
            german.Add("MenuItemRestore", "Wiederherstellen");
            polish.Add("MenuItemRestore", "Przywróć");
            french.Add("MenuItemRestore", "Restaurer");
            russian.Add("MenuItemRestore", "Восстановить");

            //Component: MenuItemCheckUpdates
            //The menu item for restoring the application
            english.Add("MenuItemCheckUpdates", "Check for Updates");
            german.Add("MenuItemCheckUpdates", "Nach Updates suchen");
            polish.Add("MenuItemCheckUpdates", "Sprawdź aktualizacje");
            french.Add("MenuItemCheckUpdates", "Vérifier les mises à jour");
            russian.Add("MenuItemCheckUpdates", "Проверить наличие обновлений");

            //Component: MenuItemAppClose
            //The menu item for restoring the application
            english.Add("MenuItemAppClose", "Close");
            german.Add("MenuItemAppClose", "Schließen");
            polish.Add("MenuItemAppClose", "Zamknij");
            french.Add("MenuItemAppClose", "Fermer");
            russian.Add("MenuItemAppClose", "Закрыть");

            //Component: newDBApplied
            //MessageBox for when a new database version is applied
            english.Add("newDBApplied", "New database version applied");
            german.Add("newDBApplied", "Neue Datenbankversion angewendet");
            polish.Add("newDBApplied", "Zastosowano nową bazę danych");
            french.Add("newDBApplied", "Nouvelle version de base de données appliquée");
            russian.Add("newDBApplied", "Применена новая версия базы данных");
            #endregion

            #region Main Window
            //Componet: installRelhaxMod
            //The button for installing the modpack
            english.Add("installRelhaxMod", "Start mod selection");
            german.Add("installRelhaxMod", "Auswahl der Mods");
            polish.Add("installRelhaxMod", "Przejdź Do Wyboru Modyfikacji");
            french.Add("installRelhaxMod", "Sélection des mods");
            russian.Add("installRelhaxMod", "Начать выбор модификаций");

            //Componet: uninstallRelhaxMod
            //
            english.Add("uninstallRelhaxMod", "Uninstall Relhax Modpack");
            german.Add("uninstallRelhaxMod", "Relhax Modpack deinstallieren");
            polish.Add("uninstallRelhaxMod", "Odinstaluj Paczkę Relhax");
            french.Add("uninstallRelhaxMod", "Désinstaller Relhax Modpack");
            russian.Add("uninstallRelhaxMod", "Удалить модпак Relhax");

            //Componet: toolTip
            //MainForm
            english.Add("mainFormToolTip", "Right click for extended description");
            german.Add("mainFormToolTip", "Rechtsklick für eine erweiterte Beschreibung");
            polish.Add("mainFormToolTip", "Rozwiń opis PPM");
            french.Add("mainFormToolTip", "Clic droit pour une description étendue");
            russian.Add("mainFormToolTip", "Нажмите правую кнопку мыши для просмотра подробного описания");

            //Componet: forceManuel
            //
            english.Add("forceManuel", "Force manual game detection");
            german.Add("forceManuel", "Erzwinge manuelle Spielerkennung");
            polish.Add("forceManuel", "Wymuś ręczną weryfikację ścieżki gry");
            french.Add("forceManuel", "Forcer détection manuel");
            russian.Add("forceManuel", "Принудительно указать папку с игрой");

            //Componet: forceManuel
            //
            english.Add("languageSelectionGB", "Language selection");
            german.Add("languageSelectionGB", "Sprachauswahl");
            polish.Add("languageSelectionGB", "Wybór języka");
            french.Add("languageSelectionGB", "Choix de langue");
            russian.Add("languageSelectionGB", "Выбрать язык");

            //Component: Forms_ENG_NAButton
            AddToAll("Forms_ENG_NAButton", "");

            //Componet: Forms_ENG_NAButtonDescription
            english.Add("Forms_ENG_NAButtonDescription", "Go to the English-speaking 'World of Tanks' forum page for the NA server");
            german.Add("Forms_ENG_NAButtonDescription", "Gehe zur englischsprachigen 'World of Tanks' Forum Seite für den NA Server");
            polish.Add("Forms_ENG_NAButtonDescription", TranslationNeeded);
            french.Add("Forms_ENG_NAButtonDescription", TranslationNeeded);
            russian.Add("Forms_ENG_NAButtonDescription", "Перейти на страницу модпака на World of Tanks NA (страница на английском)");

            //Component: FormsENG_EUButton
            AddToAll("FormsENG_EUButton", "");

            //Componet: FormsENG_EUButtonDescription
            english.Add("FormsENG_EUButtonDescription", "Go to the English-speaking 'World of Tanks' forum page for the EU server");
            german.Add("FormsENG_EUButtonDescription", "Gehe zur englischsprachigen 'World of Tanks' Forum Seite für den EU Server");
            polish.Add("FormsENG_EUButtonDescription", TranslationNeeded);
            french.Add("FormsENG_EUButtonDescription", TranslationNeeded);
            russian.Add("FormsENG_EUButtonDescription", "Перейти на страницу модпака на World of Tanks EU (страница на английском)");

            //Component: FormsENG_GERButton
            AddToAll("FormsENG_GERButton", "");

            //Componet: FormsENG_GERButtonDescription
            english.Add("FormsENG_GERButtonDescription", "Go to the German-speaking 'World of Tanks' forum page for the EU server");
            german.Add("FormsENG_GERButtonDescription", "Gehe zur deutschsprachigen 'World of Tanks' Forum Seite für den EU Server");
            polish.Add("FormsENG_GERButtonDescription", TranslationNeeded);
            french.Add("FormsENG_GERButtonDescription", TranslationNeeded);
            russian.Add("FormsENG_GERButtonDescription", "Перейти на страницу модпака на World of Tanks EU (страница на немецком)");

            //Componet: saveUserDataCB
            //
            english.Add("saveUserDataCB", "Save user data");
            german.Add("saveUserDataCB", "Mod Daten speichern");
            polish.Add("saveUserDataCB", "Zapisz ustawienia użytkownika");
            french.Add("saveUserDataCB", "Sauvegarder les données utilisateur");
            russian.Add("saveUserDataCB", "Сохранить пользовательские данные");

            //Componet: cleanInstallCB
            //
            english.Add("cleanInstallCB", "Clean installation (recommended)");
            german.Add("cleanInstallCB", "Saubere Installation (empfohlen)");
            polish.Add("cleanInstallCB", "Czysta instalacja (Zalecane)");
            french.Add("cleanInstallCB", "Installation propre (Recommandé)");
            russian.Add("cleanInstallCB", "Чистая установка (рекомендуется)");

            //Componet: cancerFontCB
            //
            english.Add("ComicSansFontCB", "Comic Sans font");
            german.Add("ComicSansFontCB", " Schriftart Comic Sans");
            polish.Add("ComicSansFontCB", "Czcionka Comic Sans");
            french.Add("ComicSansFontCB", "Police Comic Sans");
            russian.Add("ComicSansFontCB", "Шрифт Comic Sans");

            //Componet: backupModsCheckBox
            //
            english.Add("backupModsCheckBox", "Backup current mods folder");
            german.Add("backupModsCheckBox", "Sicherung des aktuellen Modsordner");
            polish.Add("backupModsCheckBox", "Zrób kopię zapasową obecnego pliku z modyfikacjami");
            french.Add("backupModsCheckBox", "Sauvegarder le dossier de mods");
            russian.Add("backupModsCheckBox", "Сделать резервную копию папки с модификациями");

            //Componet: backupModsSizeLabel
            //
            english.Add("backupModsSizeLabel", "");
            german.Add("backupModsSizeLabel", "");
            polish.Add("backupModsSizeLabel", "");
            french.Add("backupModsSizeLabel", "");
            russian.Add("backupModsSizeLabel", "");
            english.Add("backupModsSizeLabelUsed", "Backups: {0}  Size: {1}");
            german.Add("backupModsSizeLabelUsed", "Sicherungen: {0}  Größe: {1}");
            polish.Add("backupModsSizeLabelUsed", TranslationNeeded);
            french.Add("backupModsSizeLabelUsed", TranslationNeeded);
            russian.Add("backupModsSizeLabelUsed", "Бэкапов: {0}  Размер: {1}");

            english.Add("backupModsSizeLabelDescription", "Here you see the number and size of created backup folders during the last installation with activated backup option.\nClick on it to open the Backup folder viewer and you are able to delete folders by your selection.");
            german.Add("backupModsSizeLabelDescription", TranslationNeeded);
            polish.Add("backupModsSizeLabelDescription", TranslationNeeded);
            french.Add("backupModsSizeLabelDescription", TranslationNeeded);
            russian.Add("backupModsSizeLabelDescription", "Здесь вы увидите количество и размер резервных копий, созданных во время последней установки модов с включённой опцией резервного копирования.\nНажмите на неё, чтобы открыть папку с ними в Проводнике и в последствии удалить те, в которых вы не нуждаетесь.");

            english.Add("BackupDeleteFinished", "Done.\n\nAll selected Backupfolder sucessfully deleted.");
            german.Add("BackupDeleteFinished", TranslationNeeded);
            polish.Add("BackupDeleteFinished", TranslationNeeded);
            french.Add("BackupDeleteFinished", TranslationNeeded);
            russian.Add("BackupDeleteFinished", "Готово.\n\nВсе выбранные папки резервных копий успешно удалены.");

            english.Add("BackupDeleteWarning", "Realy delete all selected backup folders?\n\nIt will clean up {0} file and give you {1} additional free HDD space.");
            german.Add("BackupDeleteWarning", TranslationNeeded);
            polish.Add("BackupDeleteWarning", TranslationNeeded);
            french.Add("BackupDeleteWarning", TranslationNeeded);
            russian.Add("BackupDeleteWarning", "Точно удалить все выбранные резервные копии?\n\nЭто удалит {0} файл(а/ов) и освободит {1} на вашем жёстком диске.");

            english.Add("DeletingBackup", "Deleting Backup");
            german.Add("DeletingBackup", TranslationNeeded);
            polish.Add("DeletingBackup", TranslationNeeded);
            french.Add("DeletingBackup", TranslationNeeded);
            russian.Add("DeletingBackup", "Бэкап удаляется");
            //Componet: settingsGroupBox
            //
            english.Add("settingsGroupBox", "Settings");
            german.Add("settingsGroupBox", "Einstellungen");
            polish.Add("settingsGroupBox", "Ustawienia");
            french.Add("settingsGroupBox", "Paramètres");
            russian.Add("settingsGroupBox", "Настройки");

            //Componet: darkUICB
            //
            english.Add("darkUICB", "Dark UI");
            german.Add("darkUICB", "Dunkle Benutzeroberfläche");
            polish.Add("darkUICB", "Ciemny Interfejs");
            french.Add("darkUICB", "Interface sombre");
            russian.Add("darkUICB", "Тёмный интерфейс");

            //Componet: cleanUninstallCB
            //
            english.Add("cleanUninstallCB", "Clean uninstallation");
            german.Add("cleanUninstallCB", "Saubere deinstallation");
            polish.Add("cleanUninstallCB", "Czysta deinstalacja");
            french.Add("cleanUninstallCB", "Désinstallation propre");
            russian.Add("cleanUninstallCB", "Полное удаление");

            //Componet: saveLastInstallCB
            //
            english.Add("saveLastInstallCB", "Save selection of last install");
            german.Add("saveLastInstallCB", "Speicherung der letzten Installation");
            polish.Add("saveLastInstallCB", "Zapisz ostatnią konfigurację instalacji");
            french.Add("saveLastInstallCB", "Sauvegarder la denière configuration");
            russian.Add("saveLastInstallCB", "Запомнить выбранные моды");

            //Componet: largerFontButton
            //
            english.Add("largerFontButton", "Larger font");
            german.Add("largerFontButton", "Grössere Schriftart");
            polish.Add("largerFontButton", "Większa czcionka");
            french.Add("largeFontButton", "Grande police");
            russian.Add("largeFontButton", "Увеличить шрифт");

            //Componet: loadingImageGroupBox
            //
            english.Add("loadingImageGroupBox", "Loading image");
            german.Add("loadingImageGroupBox", "Ladebild");
            polish.Add("loadingImageGroupBox", "Ładowanie obrazka");
            french.Add("loadingImageGroupBox", "Image de chargement");
            russian.Add("loadingImageGroupBox", "Анимация загрузки");

            //Componet: standardImageRB
            //
            english.Add("standardImageRB", "Standard");
            german.Add("standardImageRB", "Standard");
            polish.Add("standardImageRB", "Podstawowe");
            french.Add("standardImageRB", "Standard");
            russian.Add("standardImageRB", "Стандартное");

            //Componet: standardImageRB
            //
            AddToAll("thirdGuardsLoadingImageRB", "3rdguards");

            //Componet: cancelDownloadButton
            //
            english.Add("cancelDownloadButton", "Cancel download");
            german.Add("cancelDownloadButton", "Download abbrechen");
            polish.Add("cancelDownloadButton", "Anuluj pobieranie");
            french.Add("cancelDownloadButton", "Anuler le téléchargement");
            russian.Add("cancelDownloadButton", "Отменить скачивание");

            //Componet: appDataFolderNotExistHeader
            //
            english.Add("appDataFolderNotExistHeader", "Could not detect WoT cache folder");
            german.Add("appDataFolderNotExistHeader", "Konnte den Cache-Ordner WoT nicht erkennen");
            polish.Add("appDataFolderNotExistHeader", "Nie wykryto foldera WoT cache");
            french.Add("appDataFolderNotExistHeader", "Impossible de détecter le dossier de cache WoT");
            russian.Add("appDataFolderNotExistHeader", "Невозможно найти папку кэша World of Tanks");

            //Componet: appDataFolderNotExist
            //
            english.Add("appDataFolderNotExist", "The installer could not detect the WoT cache folder. Continue the installation without clearing WoT cache?");
            german.Add("appDataFolderNotExist", "Der Installer konnte den WoT-Cache-Ordner nicht erkennen. Installation fortsetzen ohne den WoT-Cache zu löschen?");
            polish.Add("appDataFolderNotExist", "Instalato nie wykrył foldera cache. Czy kontynuować bez czyszczenia folderu cache?");
            french.Add("appDataFolderNotExist", "L'installateur n'as pas pus détecter le dossier de cache WoT. Continuer l'installation sans nettoyer le cache?");
            russian.Add("appDataFolderNotExist", "Установщик не обнаружил папку кэша игры. Продолжить установку без очистки кэша?");

            //Componet: viewAppUpdates
            //
            english.Add("viewAppUpdates", "View latest application updates");
            german.Add("viewAppUpdates", "Programmaktualisierungen anzeigen");
            polish.Add("viewAppUpdates", "Pokaż ostatnie zmiany w aplikacji");
            french.Add("viewAppUpdates", "Afficher les dernières MAJ de l'applications");
            russian.Add("viewAppUpdates", "Посмотреть последние обновления приложения");

            //Componet: viewDBUpdates
            //
            english.Add("viewDBUpdates", "View latest database updates");
            german.Add("viewDBUpdates", "Datenbankaktualisierungen anzeigen");
            polish.Add("viewDBUpdates", "Pokaż ostatnie zmiany w bazie danych");
            french.Add("viewDBUpdates", "Afficher les dernières MAJ de la base de données");
            russian.Add("viewDBUpdates", "Посмотреть последние обновления базы данных");

            //Componet: EnableColorChangeDefaultCB
            //
            english.Add("EnableColorChangeDefaultCB", "Enable color change");
            german.Add("EnableColorChangeDefaultCB", "Farbwechsel");
            polish.Add("EnableColorChangeDefaultCB", "Włącz zmianê kolorów");
            french.Add("EnableColorChangeDefaultCB", "Activer les changements de couleurs");
            russian.Add("EnableColorChangeDefaultCB", "Заменить цвета");

            //Componet: EnableColorChangeDefaultV2CB
            //
            english.Add("EnableColorChangeDefaultV2CB", "Enable color change");
            german.Add("EnableColorChangeDefaultV2CB", "Farbwechsel");
            polish.Add("EnableColorChangeDefaultV2CB", "Włącz zmianê kolorów");
            french.Add("EnableColorChangeDefaultV2CB", "Activer les changements de couleurs");
            russian.Add("EnableColorChangeDefaultV2CB", "Заменить цвета");

            //Componet: EnableColorChangeLegacyCB
            //
            english.Add("EnableColorChangeLegacyCB", "Enable color change");
            german.Add("EnableColorChangeLegacyCB", "Farbwechsel");
            polish.Add("EnableColorChangeLegacyCB", "Włącz zmianê kolorów");
            french.Add("EnableColorChangeLegacyCB", "Activer les changements de couleurs");
            russian.Add("EnableColorChangeLegacyCB", "Заменить цвета");

            //Componet: clearLogFilesCB
            //
            english.Add("clearLogFilesCB", "Clear log files");
            german.Add("clearLogFilesCB", "Protokolldatei löschen");
            polish.Add("clearLogFilesCB", "Wyczyść logi");
            french.Add("clearLogFilesCB", "Effacer les fichiers logs");
            russian.Add("clearLogFilesCB", "Очистить логи");

            //Componet: createShortcutsCB
            //
            english.Add("createShortcutsCB", "Create desktop shortcuts");
            german.Add("createShortcutsCB", "Erstelle desktop verknüpfungen");
            polish.Add("createShortcutsCB", "Stwórz skróty na pulpicie");
            french.Add("createShortcutsCB", "Créer des raccourcis sur le bureau");
            russian.Add("createShortcutsCB", "Создать ярлык рабочего стола");

            //Componet: InstantExtractionCB
            //
            english.Add("InstantExtractionCB", "Instant extraction mode (experimental)");
            german.Add("InstantExtractionCB", "Direkter entpack-modus (experimentell)");
            polish.Add("InstantExtractionCB", "Tryb szybkiego wypakowywania (eksperymentalny)");
            french.Add("InstantExtractionCB", "Mode d'extraction instantané (expérimental)");
            russian.Add("InstantExtractionCB", "Режим мгновенной распаковки (экспериментальный)");

            //Componet: SuperExtractionCB
            //
            english.Add("SuperExtractionCB", "Multicore extraction mode (experimental)");
            german.Add("SuperExtractionCB", "Mehrkern Extraktion (experimentell)");
            polish.Add("SuperExtractionCB", "Wsparcie wielu rdzeni (eksperymentalne)");
            french.Add("SuperExtractionCB", "Mode d'extraction multicoeur (expérimental)");
            russian.Add("SuperExtractionCB", "Многопроцессорный режим распаковки (экспериментальный)");

            //Componet: DefaultUninstallModeRB
            //
            english.Add("DefaultUninstallModeRB", "Default");
            german.Add("DefaultUninstallModeRB", "Standard");
            polish.Add("DefaultUninstallModeRB", "Standard");
            french.Add("DefaultUninstallModeRB", "Défaut");
            russian.Add("DefaultUninstallModeRB", "Стандартный");

            //Componet: CleanUninstallModeRB
            //
            english.Add("CleanUninstallModeRB", "Quick");
            german.Add("CleanUninstallModeRB", "Schnell");
            polish.Add("CleanUninstallModeRB", "Szybka");
            french.Add("CleanUninstallModeRB", "Rapide");
            russian.Add("CleanUninstallModeRB", "Быстрый");

            //Componet: ExportModeCB
            //
            english.Add("ExportModeCB", "Export Mode");
            german.Add("ExportModeCB", "Export-Modus");
            polish.Add("ExportModeCB", "Tryb wyboru ścieżki wypakowywania");
            french.Add("ExportModeCB", "Mode d'exportation");
            russian.Add("ExportModeCB", "Режим экспорта");

            //Section: ExportSelectWoTVersion

            //Component: ExportWindowDesctiption
            //
            english.Add("ExportWindowDesctiption", "Select the version of WoT you wish to export for");
            german.Add("ExportWindowDesctiption", "Wählen Sie die Version von WoT, für die Sie exportieren möchten");
            polish.Add("ExportWindowDesctiption", "Wybór wersji WoT");
            french.Add("ExportWindowDesctiption", "Sélection de la version de WoT que vous souhaitez exporter");
            russian.Add("ExportWindowDesctiption", "Выберите версию WoT, для которой нужно произвести экспорт");

            //Section: FirstLoadHelper

            //Componet: helperText
            //
            english.Add("helperText", "Welcome to the Relhax Modpack! I have tried to make the modpack as straight-forward as possible, but questions may still arise." +
                " Hover over a setting to have it explained. You won't see this dialog box again, unless you delete the settings xml file.");
            german.Add("helperText", "Willkommen im Relhax Modpack! Ich habe versucht, das Modpack so einfach wie möglich zu gestalten, aber Fragen können dennoch entstehen." +
                " Rechtsklick auf eine Einstellung erklärt diese dann. Du siehst diese Dialogbox nicht mehr, ausser du löscht die xml Datei.");
            polish.Add("helperText", "Witamy w paczce Relhax! Próbowałem stworzyć jak najprostszą w użytku paczkę modyfikacji, ale wciąż możesz mieć pytania." +
                " Kliknik PPM na opcji, by wyświetlić opis. Nie zobaczysz tej wiadomości ponownie, dopóki nie usuniesz pliku ustawień xml.");
            french.Add("helperText", "Bienvenue au Modpack Relhax! J'ai aissayé de faire le modpack le plus simple possible, mais des questions peuvent survenir." +
                " Survolez un paramètre pour voire une explication. Vous n'allez plus voire cette boite, sauf si vous supprimez le fichier de configuration xml ");
            russian.Add("helperText", "Добро пожаловать в модпак Relhax! Я пытался сделать модпак максимально простым для использования, но вопросы всё же могут возникнуть." +
                " Наведите курсор мыши на любую настройку, и вы увидите пояснение к ней. Данное диалоговое окно больше не появится, если не удалите XML-файл с настройками.");

            //Component: notifyIfSameDatabaseCB
            english.Add("notifyIfSameDatabaseCB", "Inform if no new database available");
            german.Add("notifyIfSameDatabaseCB", "Hinweis wenn keine Aktuallisierungen erfolgt sind");
            polish.Add("notifyIfSameDatabaseCB", "Poinformuj, jeśli nie będzie dostępna nowa baza danych");
            french.Add("notifyIfSameDatabaseCB", "Informer si aucune nouvelle base de données est disponible");
            russian.Add("notifyIfSameDatabaseCB", "Уведомлять при отстутсвии новых баз данных");

            //Component: ShowInstallCompleteWindow
            english.Add("ShowInstallCompleteWindowCB", "Show install complete window");
            german.Add("ShowInstallCompleteWindowCB", "Zeigt \"Installation fertig\" Fenster");
            polish.Add("ShowInstallCompleteWindowCB", "Pokaż okno akcji po instalacji");
            french.Add("ShowInstallCompleteWindowCB", "Afficher la fenêtre \"installation terminé\"");
            russian.Add("ShowInstallCompleteWindowCB", "Показывать окно \"Установка завершена\"");

            //Component: ShowAdvancedSettingsLink
            english.Add("ShowAdvancedSettingsLink", "Show advanced settings");
            german.Add("ShowAdvancedSettingsLink", "Erweiterte Einstellungen");
            polish.Add("ShowAdvancedSettingsLink", "Pokaż ustawienia zaawansowane");
            french.Add("ShowAdvancedSettingsLink", "Afficher les paramètres avancé");
            russian.Add("ShowAdvancedSettingsLink", "Показать расширенные настройки");

            //Component: ApplicationVersionLabel
            AddToAll("ApplicationVersionLabel", "Application");

            //Component: ErrorCounterLabel
            AddToAll("ErrorCounterLabel", "Error Counter: ");

            //Component: DPIAUTO
            AddToAll("DPIAUTO", "AUTO");

            //Component: DPI100
            AddToAll("DPI100", "DPI 1.0x");

            //Component: DPI125
            AddToAll("DPI125", "DPI 1.25x");

            //Component: DPI175
            AddToAll("DPI175", "DPI 1.75x");

            //Component: DPI225
            AddToAll("DPI225", "DPI 2.25x");

            //Component: DPI275
            AddToAll("DPI275", "DPI 2.75x");

            //Component: fontSize100
            AddToAll("fontSize100", "Font 1.0x");

            //Component: fontSize125
            AddToAll("fontSize125", "Font 1.25x");

            //Component: fontSize175
            AddToAll("fontSize175", "Font 1.75x");

            //Component: fontSize225
            AddToAll("fontSize225", "Font 2.25x");

            //Component: fontSize275
            AddToAll("fontSize275", "Font 2.75x");
            #endregion

            #region ModSelectionList
            //Componet: continueButton
            //
            english.Add("continueButton", "Install");
            german.Add("continueButton", "Installieren");
            polish.Add("continueButton", "Zainstaluj");
            french.Add("continueButton", "Installer");
            russian.Add("continueButton", "Установить");

            //Componet: cancelButton
            //
            english.Add("cancelButton", "Cancel");
            german.Add("cancelButton", "Abbrechen");
            polish.Add("cancelButton", "Anuluj");
            french.Add("cancelButton", "Anuler");
            russian.Add("cancelButton", "Отмена");

            //Componet: helpLabel
            //
            english.Add("helpLabel", "Right-click a mod name to preview it");
            german.Add("helpLabel", "Klick mit rechten Maustaste auf einen Mod-Namen, um eine Vorschau zu sehen");
            polish.Add("helpLabel", "PPM by wyświetlić opis");
            french.Add("helpLabel", "Cliquez droit sur un nom de mod pour un apercu");
            russian.Add("helpLabel", "Нажмите правой кнопкой мыши на название мода для предпросмотра");

            //Componet: loadConfigButton
            //
            english.Add("loadConfigButton", "Load selection");
            german.Add("loadConfigButton", "Auswahl laden");
            polish.Add("loadConfigButton", "Wczytaj konfigurację z pliku");
            french.Add("loadConfigButton", "Charger une configuration");
            russian.Add("loadConfigButton", "Загрузить шаблон настроек");

            //Componet: saveConfigButton
            //
            english.Add("saveConfigButton", "Save selection");
            german.Add("saveConfigButton", "Auswahl speichern");
            polish.Add("saveConfigButton", "Zapisz konfigurację w pliku");
            french.Add("saveConfigButton", "Sauvegarder une configuration");
            russian.Add("saveConfigButton", "Сохранить шаблон настроек");
      

            //Componet: label2
            //
            english.Add("TabIndicatesTB", "\"*\" (asterisk) tab indicates single selection tab");
            german.Add("TabIndicatesTB", "Bei einem Tab mit einem\"*\" (Sternchen), kann nur eins der primären Mods ausgewählt werden.");
            polish.Add("TabIndicatesTB", "\"*\" wskazuje pojedynczą kartę wyboru");
            french.Add("TabIndicatesTB", "Onglet \"*\" indique un onglet a sélection unique");
            russian.Add("TabIndicatesTB", "Вкладка со знаком звёздочки (\"*\") обозначает выбор только одного компонента");

            //Componet: clearSelectionsButton
            //
            english.Add("clearSelectionsButton", "Clear selections");
            german.Add("clearSelectionsButton", "Auswahl löschen");
            polish.Add("clearSelectionsButton", "Wyczyść wybór");
            french.Add("clearSelectionsButton", "Réinitialiser la sélection");
            russian.Add("clearSelectionsButton", "Снять все галочки");

            //Componet: readingDatabase
            //
            english.Add("readingDatabase", "Reading database");
            german.Add("readingDatabase", "Lese datenbank");
            polish.Add("readingDatabase", "Wczytywanie baz danych");
            french.Add("readingDatabase", "Chargement de la base de données");
            russian.Add("readingDatabase", "Читается база данных...");

            //Componet: buildingUI
            //
            english.Add("buildingUI", "Building UI");
            german.Add("buildingUI", "Erstelle UI");
            polish.Add("buildingUI", "Budowanie interfejsu");
            french.Add("buildingUI", "Construction de l'interface");
            russian.Add("buildingUI", "Построение интерфейса...");

            //Componet: checkingCache
            //
            english.Add("checkingCache", "Checking download cache of ");
            german.Add("checkingCache", "Überprüfen des Download-Cache von");
            polish.Add("checkingCache", "Sprawdzanie ściągniętego cache dla");
            french.Add("checkingCache", "vérification du cache de téléchargement de");
            russian.Add("checkingCache", "Проверяается кэш загруки ");

            //Section: Preview
            //Componet: descriptionBox
            //
            english.Add("noDescription", "no description provided");
            german.Add("noDescription", "keine Beschreibung verfügbar");
            polish.Add("noDescription", "nie podano opisu");
            french.Add("noDescription", "nPas de description fournie");
            russian.Add("noDescription", "Описание отсутствует");

            //Componet: updateBox
            //
            english.Add("noUpdateInfo", "No update info provided");
            german.Add("noUpdateInfo", "keine Aktualisierungsinformationen verfügbar");
            polish.Add("noUpdateInfo", "brak informacji o aktualizacji");
            french.Add("noUpdateInfo", "Aucune information de mise à jour fournie");
            russian.Add("noUpdateInfo", "Отсутствует информация об обновлении");
            

            //Componet: NextPicButton
            //
            english.Add("NextPicButton", "next");
            german.Add("NextPicButton", "weiter");
            polish.Add("NextPicButton", "Dalej");
            french.Add("NextPicButton", "Suivant");
            russian.Add("NextPicButton", "след.");

            //Componet: PreviousPicButton
            //
            english.Add("PreviousPicButton", "previous");
            german.Add("PreviousPicButton", "zurück");
            polish.Add("PreviousPicButton", "Wstecz");
            french.Add("PreviousPicButton", "Précedent");
            russian.Add("PreviousPicButton", "пред.");

            //Componet: DevLinkLabel
            //
            english.Add("DevLinkLabel", "Developer website");
            german.Add("DevLinkLabel", "Entwickler webseite");
            polish.Add("DevLinkLabel", "Strona Dewelopera");
            french.Add("DevLinkLabel", "Site web du développeur");
            russian.Add("DevLinkLabel", "Сайт разработчика");
            #endregion

            #region Update Window
            //Componet: updateAcceptButton
            //
            english.Add("updateAcceptButton", "yes");
            german.Add("updateAcceptButton", "ja");
            polish.Add("updateAcceptButton", "Tak");
            french.Add("updateAcceptButton", "Oui");
            russian.Add("updateAcceptButton", "Да");

            //Componet: updateDeclineButton
            //
            english.Add("updateDeclineButton", "no");
            german.Add("updateDeclineButton", "nein");
            polish.Add("updateDeclineButton", "Nie");
            french.Add("updateDeclineButton", "Non");
            russian.Add("updateDeclineButton", "Нет");

            //Componet: newVersionAvailableLabel
            //
            english.Add("newVersionAvailableLabel", "New version available");
            german.Add("newVersionAvailableLabel", "Neue version verfügbar");
            polish.Add("newVersionAvailableLabel", "Dostępna nowa wersja");
            french.Add("newVersionAvailableLabel", "Nouvelle version disponible");
            russian.Add("newVersionAvailableLabel", "Доступна новая версия");

            //Componet: updateQuestionLabel
            //
            english.Add("updateQuestionLabel", "Update?");
            german.Add("updateQuestionLabel", "Aktualisieren?");
            polish.Add("updateQuestionLabel", "Zaktualizować?");
            french.Add("updateQuestionLabel", "Mettre à jour?");
            russian.Add("updateQuestionLabel", "Обновить?");

            //Componet: problemsUpdatingLabel
            //
            english.Add("problemsUpdatingLabel", "If you are having problems updating, please");
            german.Add("problemsUpdatingLabel", "Wenn Sie Probleme mit der Aktualisierung haben, bitte");
            polish.Add("problemsUpdatingLabel", "Jeśli masz problemy z aktualizają proszę");
            french.Add("problemsUpdatingLabel", "Si vous avez des problèmes avec la mise à jour, s'il vous plaît");
            russian.Add("problemsUpdatingLabel", "При наличии проблем в процессе обновлений, пожалуйста,");
      

            //Componet: 
            //
            english.Add("clickHereUpdateLabel", "click here");
            german.Add("clickHereUpdateLabel", "klick hier");
            polish.Add("clickHereUpdateLabel", "kliknij tutaj");
            french.Add("clickHereUpdateLabel", "Cliquez ici");
            russian.Add("clickHereUpdateLabel", "нажмите сюда.");
            #endregion

            #region Please Wait Window
            //Componet: label1
            //
            english.Add("label1", "Loading...please wait...");
            german.Add("label1", "Lädt...bitte warten...");
            polish.Add("label1", "Ładowanie... proszę czekać...");
            french.Add("label1", "Chargement... Patientez, s'il vous plaît...");
            russian.Add("label1", "Идёт загрузка, пожалуйста, подождите...");
            #endregion

            #region MainWindow Messages and Descriptions
            //Componet: 
            //
            english.Add("Downloading", "Downloading");
            german.Add("Downloading", "Wird heruntergeladen");
            polish.Add("Downloading", "Pobieranie");
            french.Add("Downloading", "Téléchargement");
            russian.Add("Downloading", "Идёт скачивание");

            //Componet: 
            //
            english.Add("patching", "Patching");
            german.Add("patching", "Patching");
            polish.Add("patching", "Patchowanie");
            french.Add("patching", "Patching");
            russian.Add("patching", "Идёт процесс патчинга");

            //Componet: 
            //
            english.Add("done", "Done");
            german.Add("done", "Fertig");
            polish.Add("done", "Zrobione");
            french.Add("done", "Terminé");
            russian.Add("done", "Готово");

            //Componet: 
            //
            english.Add("cleanUp", "Clean up resources");
            german.Add("cleanUp", "Bereinige Ressourcen");
            polish.Add("cleanUp", "Oczyszczanie zasobów");
            french.Add("cleanUp", "Nettoyer les ressources");
            russian.Add("cleanUp", "Очистка ресурсов");
            
            //Componet: 
            //
            english.Add("idle", "Idle");
            german.Add("idle", "Leerlauf");
            polish.Add("idle", "Bezczynny");
            french.Add("idle", "En attente");
            russian.Add("idle", "Ожидание");

            //Componet: 
            //
            english.Add("status", "Status:");
            german.Add("status", "Status:");
            polish.Add("status", "Stan:");
            french.Add("status", "Statut");
            russian.Add("status", "Состояние:");

            //Componet: 
            //
            english.Add("canceled", "Canceled");
            german.Add("canceled", "Abgebrochen");
            polish.Add("canceled", "Anulowano");
            french.Add("canceled", "Anulé");
            russian.Add("canceled", "Отменено");

            //Componet: 
            //
            english.Add("appSingleInstance", "Checking for single instance");
            german.Add("appSingleInstance", "Prüfung auf Einzelinstanz");
            polish.Add("appSingleInstance", "Sprawdzanie ");
            french.Add("appSingleInstance", "Vérification d'instance unique");
            russian.Add("appSingleInstance", "Проверяется наличие только одного процесса");

            //Componet: 
            //
            english.Add("checkForUpdates", "Checking for updates");
            german.Add("checkForUpdates", "Auf Updates prüfen");
            polish.Add("checkForUpdates", "Sprawdzanie aktualizacji");
            french.Add("checkForUpdates", "Vérification de mise à jour");
            russian.Add("checkForUpdates", "Проверяется наличие обновлений");

            //Componet: 
            //
            english.Add("verDirStructure", "Verifying directory structure");
            german.Add("verDirStructure", "Verifizierung der Verzeichnisstruktur");
            polish.Add("verDirStructure", "Sprawdzanie struktury dostępu");
            french.Add("verDirStructure", "Vérification de la structure du directoire");
            russian.Add("verDirStructure", "Проверяется структура каталогов");

            //Componet: 
            //
            english.Add("loadingSettings", "Loading settings");
            german.Add("loadingSettings", "Einstellungen laden");
            polish.Add("loadingSettings", "Ładowanie ustawnień");
            french.Add("loadingSettings", "Chargement des paramètres");
            russian.Add("loadingSettings", "Загружаются настройки");

            //Componet: 
            //
            english.Add("loadingTranslations", "Loading translations");
            german.Add("loadingTranslations", "Laden der Übersetzungen");
            polish.Add("loadingTranslations", "ładowanie tłumaczenia");
            french.Add("loadingTranslations", "Chargement des traductions");
            russian.Add("loadingTranslations", "Загружаются переводы на другие языки");

            //Componet: 
            //
            english.Add("loading", "Loading");
            german.Add("loading", "Laden");
            polish.Add("loading", "Ładowanie");
            french.Add("loading", "Chargement de");
            russian.Add("loading", "Загрузка...");

            //Componet: 
            //
            english.Add("uninstalling", "Uninstalling");
            german.Add("uninstalling", "Deinstallieren");
            polish.Add("uninstalling", "Deinstalacja w toku");
            french.Add("uninstalling", "Désinstallation");
            russian.Add("uninstalling", "Удаляется...");

            //Componet: 
            //
            english.Add("installingFonts", "Installing fonts");
            german.Add("installingFonts", "Installieren von Schriftarten");
            polish.Add("installingFonts", "Instalowanie czcionek");
            french.Add("installingFonts", "Installation des polices");
            russian.Add("installingFonts", "Устанавливаются шрифты");

            //Componet: 
            //
            english.Add("loadingExtractionText", "Loading extraction text");
            german.Add("loadingExtractionText", "Extraktionstext laden");
            polish.Add("loadingExtractionText", "Ładowanie tekstu");
            french.Add("loadingExtractionText", "Chargement du texte d'extraction");
            russian.Add("loadingExtractionText", "Загружается извлекаемый текст");

            //Componet: 
            //
            english.Add("extractingRelhaxMods", "Extracting Relhax mods");
            german.Add("extractingRelhaxMods", "Extrahieren von Relhax mods");
            polish.Add("extractingRelhaxMods", "Wypakowywanie modyfikacji mods");
            french.Add("extractingRelhaxMods", "Extraction des mods Relhax");
            russian.Add("extractingRelhaxMods", "Распаковываются моды Relhax");

            //Componet: 
            //
            english.Add("extractingUserMods", "Extracting user mods");
            german.Add("extractingUserMods", "Extrahieren von benutzerdefinierten mods");
            polish.Add("extractingUserMods", "Wypakowywanie modyfikacji użytkownika");
            french.Add("extractingUserMods", "Extraction des mods d'utilisateur");
            russian.Add("extractingUserMods", "Распаковываются пользовательские моды");

            //Componet: 
            //
            english.Add("copyingFile", "Copying file");
            german.Add("copyingFile", "Kopieren von Dateien");
            polish.Add("copyingFile", "Kopiowanie plików");
            french.Add("copyingFile", "Copie des fichiers");
            russian.Add("copyingFile", "Копирование файла");

            //Componet: 
            //
            english.Add("deletingFile", "Deleting file");
            german.Add("deletingFile", "Lösche Datei");
            polish.Add("deletingFile", "Usuwanie plików");
            french.Add("deletingFile", "Supression du fichier");
            russian.Add("deletingFile", "Удаление файла");

            //Componet: 
            //
            english.Add("of", "of");
            german.Add("of", "von");
            polish.Add("of", "z");
            french.Add("of", "de");
            russian.Add("of", "из");

            //Componet: 
            //
            english.Add("forceManuelDescription", "This option is for forcing a manual World of Tanks game" +
                    "location detection. Check this if you are having problems with automatically locating the game.");
            german.Add("forceManuelDescription", "Diese Option ist für die manuelle selektion des World of Tanks Spiel-" +
                    "speicherortes. Nutze dies wenn Du Probleme mit der automatischen Suche des Spiels hast.");
            polish.Add("forceManuelDescription", "Ta opcja wymusza ręczne znalezienie lokacji gry World of Tanks." +
                    "Zaznacz, jeśli masz problem z automatycznym znalezieniem ścieżki dostępu do gry.");
            french.Add("forceManuelDescription", "Cette option consiste à forcer une détection manuel" +
                    "de World of Tanks. Sélectionnez cette option si vous rencontrez des problèmes pour localiser automatiquement le jeu.");
            russian.Add("forceManuelDescription", "Эта опция для принудительного указания папки с World of Tanks." +
                    "Поставьте галочку только в случае проблем с автоматическим определением расположения игры.");        

            //Componet: 
            //
            english.Add("cleanInstallCBDescription", "This recommended option will empty your res_mods folder before installing" +
                    " your new mod selections. Unless you know what you are doing, it is recommended that you keep this on to avoid problems.");
            german.Add("cleanInstallCBDescription", "Diese empfohlene Option leert den Ordner res_mods vor der Installation" +
                    "Deiner neuen Mod-Auswahl. Bis du genau weißt, was du tust, empfohlen wir, dass du das weiter behältst, um Probleme zu vermeiden.");
            polish.Add("cleanInstallCBDescription", "To rekomendowane ustawienie usunie zawartość folderu res_mods przed instalacją" +
                     "nowej konfiguracji modów. Jeśli nie wiesz co robisz zalecamy włączyć tą opcję, aby uniknąć problemów.");
            french.Add("cleanInstallCBDescription", "Cette option recommandé vas nettoyer le dossier res_mods avant d'installer" +
                    "votre nouvelle sélection de mods. À moins que vous ne sachiez ce que vous faites, il est recommandé de laisser ceci activé pour éviter des problèmes.");
            russian.Add("cleanInstallCBDescription", "Данная рекомендуемая опция перед установкой произведёт очистку res_mods, чтобы установить выбранные вами моды." +
                    "Снимите галочку только в том случае, если понимаете, что делаете, но это не желательно.");        

            //Componet: 
            //
            english.Add("backupModsCheckBoxDescription", "Select this to make a backup of your current res_mods folder." +
                    "They are stored in the 'RelHaxModBackup' folder, saved in a folder inside by a time stamp.");
            german.Add("backupModsCheckBoxDescription", "Wähle diese Option, um eine Sicherungskopie Deines aktuellen res_mods-Ordners zu erstellen." +
                    "Sie werden im Ordner 'RelHaxModBackup' gespeichert und in einem Ordner nach innen durch einen Zeitstempel gespeichert.");
            polish.Add("backupModsCheckBoxDescription", "Zaznacz, aby zrobić kopię zapasową folderu res_mods." +
                     "Pliki będą przechowane w folderze RelHaxModBackup, zapisane w folderze oznaczonym datą.");
            french.Add("backupModsCheckBoxDescription", "Choisissez ceci pour faire une sauvegarde du dossier res_mods actuel"); 
            russian.Add("backupModsCheckBoxDescription", "Выберите этот пункт для создания резервной копии res_mods." +
                     "Они будут храниться в папке 'RelHaxModBackup' и иметь метку с датой.");            

            //Componet: 
            //
            english.Add("ComicSansFontCBDescription", "Enable Comic Sans font");
            german.Add("ComicSansFontCBDescription", "Schriftart Comic Sans aktivieren");
            polish.Add("ComicSansFontCBDescription", "Włącz czcionkę Comic Sans");
            french.Add("ComicSansFontCBDescription", "Activé la police Comic Sans");
            russian.Add("ComicSansFontCBDescription", "Включить шрифт Comic Sans");

            //Componet: 
            //
            english.Add("enlargeFontDescription", "Enlarge font");
            german.Add("enlargeFontDescription", "Schriftart vergrössern");
            polish.Add("enlargeFontDescription", "Powiększ czcionkę");
            french.Add("enlargeFontDescription", "Agrandir la police");
            russian.Add("enlargeFontDescription", "Увеличить шрифт");

            //Componet: 
            //
            english.Add("standardImageRBDescription", "Select a loading gif for the mod preview window.");
            german.Add("standardImageRBDescription", "Wähle ein Lade-Gif fuer das Vorschaufenster des Mods.");
            polish.Add("standardImageRBDescription", "Załaduj gif w oknie podglądu.");
            french.Add("standardImageRBDescription", "Choisissez un GIF de chargement pour l'apercu des mods");
            russian.Add("standardImageRBDescription", "Выберите GIF для анимации загрузки в окне предпросмотра.");

            //Componet: 
            //
            english.Add("thirdGuardsLoadingImageRBDescription", "Select a loading gif for the mod preview window.");
            german.Add("thirdGuardsLoadingImageRBDescription", "Wähle ein Lade-Gif fuer das Vorschaufenster des Mods.");
            polish.Add("thirdGuardsLoadingImageRBDescription", "Załaduj gif w oknie podglądu.");
            french.Add("thirdGuardsLoadingImageRBDescription", "Choisissez un GIF de chargement pour l'apercu des mods");
            russian.Add("thirdGuardsLoadingImageRBDescription", "Выберите GIF для анимации загрузки в окне предпросмотра.");
            
            //Componet: 
            //
            english.Add("saveLastInstallCBDescription", "If this is selected, the installer will load the last saved selection.");
            german.Add("saveLastInstallCBDescription", "Wenn dies ausgewählt ist, lädt das Installationsprogramm die zuletzt installierte Konfiguration im Auswahlfenster, die Du verwendet hast.");
            polish.Add("saveLastInstallCBDescription", "Przy zaznaczeniu, instalator załaduje ostatnią użytą konfigurację w oknie wyboru modyfikacji.");
            french.Add("saveLastInstallCBDescription", "Si cette option est sélectionnée, L'installateur affichera, lors de la fenêtre de sélection, la denière configuration que vous avez utilisé");
            russian.Add("saveLastInstallCBDescription", "Если выбрано, то установщик загрузит последнюю выбранную вами конфигурацию.");

            //Componet:
            //
            english.Add("saveUserDataCBDescription", "If this is selected, the installer will save user created data (like session stats from previous battles)");
            german.Add("saveUserDataCBDescription", "Wenn dies ausgewählt ist, speichert das Installationsprogramm die vom Benutzer erstellten Daten (wie Sitzungsstatistiken aus früheren Gefechten)");
            polish.Add("saveUserDataCBDescription", "Przy zaznaczeniu, instalator zachowa pliki danych użytkownika (takie jak statystyki sesji z poprzednich bitew)");
            french.Add("saveUserDataCBDescription", "Si cette option est sélectionnée, l'installateur vas sauvegarder les données créé par l'utilisateur (Comme les stats de la session des batailles précédentes");
            russian.Add("saveUserDataCBDescription", "Если выбрано, то установщик сохранит пользовательские данные (как сессионную статистику из предыдущих боев, к примеру)");

            //Componet: 
            //
            english.Add("darkUICBDescription", "Toggle the DarkUI mode. Useful for working with the modpack at night.");
            german.Add("darkUICBDescription", "Auf dunklen UI Modus umschalten. Nützlich für die Arbeit mit dem Modpack in der Nacht.");
            polish.Add("darkUICBDescription", "Zmień interfejs na ciemny. Przydatneprzy pracy z paczką w nocy.");
            french.Add("darkUICBDescription", "Activer l'interface sombre. Utile pour utilisé le modpack pendant la nuit");
            russian.Add("darkUICBDescription", "Включает тёмный интерфейс. Полезно при работе с модпаком ночью.");

            //Componet: 
            //
            english.Add("failed_To_Download_1", "Failed to download:");
            german.Add("failed_To_Download_1", "Fehler beim Herunterladen:");
            polish.Add("failed_To_Download_1", "Ściąganie zakończone niepowodzeniem, plik:");
            french.Add("failed_To_Download_1", "Échec de téléchargement:");
            russian.Add("failed_To_Download_1", "Не удалось загрузить:");

            //Componet: 
            //
            english.Add("failed_To_Download_2", "If you know which mod this is, uncheck it and you should be fine. It will be fixed soon. Restart this when it exits");
            german.Add("failed_To_Download_2", "Wenn du weisst, welcher Mod das ist, deaktiviere ihn und alles sollte funktionieren. Es wird bald behoben. Starte das Programm neu nach dem beenden.");
            polish.Add("failed_To_Download_2", "Jeśli wiesz który to mod, odznacz go i wszystko powinno byćw porządku. Wkrótce naprawimy błąd. Zrestartuj, jeśli problem pojawia się ponownie.");
            french.Add("failed_To_Download_2", "Si vous savez quel mod est la cause, déséléectionnez celui-ci. Un corrigé vas être disponible bientôt. Redémarrez ceci a la fermeture");
            russian.Add("failed_To_Download_2", "Если вы знаете, что это за мод, снимите галочку с него и всё должно встать на свои места. Скоро это будет исправлено. Перезапустите программу, когда она закроется.");

            //Component: update check against online app version
            //
            english.Add("failedManager_version", "Current Beta application is outdated and must be updated against stable channel. No new Beta version online now.");
            german.Add("failedManager_version", TranslationNeeded);
            polish.Add("failedManager_version", TranslationNeeded);
            french.Add("failedManager_version", TranslationNeeded);
            russian.Add("failedManager_version", "Текущая бета-версия неактуальна и должна быть переведена на канал стабильных версий. Новых бета-версий в данный момент не было выпущено.");

            //Component: initial download managerInfo.dat
            //
            english.Add("currentBetaAppOutdated", "Failed to get 'manager_version.xml'\n\nApplication will be terminated.");
            german.Add("currentBetaAppOutdated", "Fehler beim lesen der 'manager_version.xml' Datei.\n\nProgramm wird abgebrochen.");
            polish.Add("currentBetaAppOutdated", "Nie udało się uzyskać 'manager_version.xml'\n\nApplication zostanie zakończona.");
            french.Add("currentBetaAppOutdated", "Impossible d'obtenir 'manager_version.xml'\n\nL'application sera terminée.");
            russian.Add("currentBetaAppOutdated", "Не удалось получить 'manager_version.xml'\n\nПриложение будет закрыто.");

            //Componet: 
            //
            english.Add("fontsPromptInstallHeader", "Admin to install fonts?");
            german.Add("fontsPromptInstallHeader", "Admin zum Installieren von Schriftarten?");
            polish.Add("fontsPromptInstallHeader", "Uprawnienia administratora, by zainstalować czcionki?");
            french.Add("fontsPromptInstallHeader", "Admin pour installer les polices?");
            russian.Add("fontsPromptInstallHeader", "Права администратора для установки шрифтов?");

            //Componet: 
            //
            english.Add("fontsPromptInstallText", "Do you have admin rights to install fonts?");
            german.Add("fontsPromptInstallText", "Hast Du Admin-Rechte um Schriftarten zu installieren?");
            polish.Add("fontsPromptInstallText", "Czy masz uprawnienia administratora zainstalować czcionki?");
            french.Add("fontsPromptInstallText", "Avez-vous les droits d'administrateur installer des polices?");
            russian.Add("fontsPromptInstallText", "У вас есть права администратора, необходимые для установки шрифтов?");

            //Componet: 
            //
            english.Add("fontsPromptError_1", "Unable to install fonts. Some mods may not work properly. Fonts are located in ");
            german.Add("fontsPromptError_1", "Schriftarten können nicht installiert werden. Einige Mods funktionieren möglicherweise nicht richtig. Schriften befinden sich in ");
            polish.Add("fontsPromptError_1", "Niepowodzenie przy instalacji czcionek. Niektóre modyfikacje mogą nie działać prawidłowo. Czcionki znajdują się w ");
            french.Add("fontsPromptError_1", "Impossible d'installer les polices. Certain mods peut mal fonctionner. Les polices sont situé dans ");
            russian.Add("fontsPromptError_1", "Не удалось установить шрифты. Некоторые моды могут работать некорректно. Шрифты расположены в ");

            //Componet: 
            //
            english.Add("fontsPromptError_2", "\\_fonts. Either install them yourself or run this again as Administrator.");
            german.Add("fontsPromptError_2", "\\_fonts. Entweder installiere sie selbst oder führe der Relhax Manager erneut als Administrator aus.");
            polish.Add("fontsPromptError_2", "\\_fonts. Albo zainstalujesz je własnoręcznie, albo uruchom jako administrator.");
            french.Add("fontsPromptError_2", "\\_fonts. Installez les polices manuellement ou redémarrez avec les droits Administrateur");
            russian.Add("fontsPromptError_2", "\\_fonts. Попробуйте установить их самостоятельно или перезапустите программу от имени администратора.");

            //Componet: 
            //
            english.Add("cantDownloadNewVersion", "Unable to download new version, exiting.");
            german.Add("cantDownloadNewVersion", "Die neue Version kann nicht heruntergeladen werden.");
            polish.Add("cantDownloadNewVersion", "Niepowodzenie przy pobieraniu nowej wersji.");
            french.Add("cantDownloadNewVersion", "Échec du téléchargement des mise à jours. Fermeture.");
            russian.Add("cantDownloadNewVersion", "Невозможно загрузить новую версию, приложение будет закрыто.");

            //Componet: 
            //
            english.Add("failedCreateUpdateBat", "Unable to create update process.\n\nPlease manually delete the file:\n{0}\n\nrename file:\n{1}\nto:\n{2}\n\nDirectly jump to the folder?");
            german.Add("failedCreateUpdateBat", "Updateprozess kann leider nicht erstellt werden.\n\nLösche bitte diese Datei von Hand:\n{0}\n\nbenennte diese" +
                " Datei:\n{1}\nin diese um:\n{2}\n\nDirekt zum Ordner springen?");
            polish.Add("failedCreateUpdateBat", "Nie można zaktualizować.\n\nProszę ręcznie usunąć plik:\n{0}\n\nrzmienić nazwę pliku:\n{1}\nna:\n{2}\n\nCzy chcesz otworzyć lokalizację pliku?");
            french.Add("failedCreateUpdateBat", "fichier:\n{0}\n\nrenamefile:\n{1}\nto:\n{2}\n\nAfficher le dossier?");
            russian.Add("failedCreateUpdateBat", "Невозможно создать процесс программы обновления.\n\nУдалите вручную этот файл:\n{0}\n\nПереименуйте файл:\n{1}\nна:\n{2}\n\nПерейти к папке прямо сейчас?");

            //Componet: 
            //
            english.Add("cantStartNewApp", "Unable to start application, but it is located in \n");
            german.Add("cantStartNewApp", "Kann die Anwendung nicht starten, aber sie befindet sich in \n");
            polish.Add("cantStartNewApp", "Niepowodzenie przy uruchamianiu aplikacji znajdującej się w \n");
            french.Add("cantStartNewApp", "Échec du lancement de l'application, mais elle est situé dans \n");
            russian.Add("cantStartNewApp", "Не удалось запустить приложение, но оно расположено в \n");

            //Componet: 
            //
            english.Add("autoDetectFailed", "The auto-detection failed. Please use the 'force manual' option");
            german.Add("autoDetectFailed", "Die automatische Erkennung ist fehlgeschlagen. Bitte benutzen Sie die 'erzwinge manuelle' Option");
            polish.Add("autoDetectFailed", "Niepowodzenie automatycznego wykrywania. Proszę wybrać opcję ręcznego znajdowania ścieżki gry.");
            french.Add("autoDetectFailed", "Échec de la détection automatique. Utilisez l'option 'Forcer détection manuel'");
            russian.Add("autoDetectFailed", "Сбой автоматического обнаружения игры. Используйте опцию принудительного указания.");

            //Componet: MainWindow_Load
            //
            english.Add("anotherInstanceRunning", "Another Instance of the Relhax Manager is already running");
            german.Add("anotherInstanceRunning", "Eine weitere Instanz des Relhax Manager  läuft bereits");
            polish.Add("anotherInstanceRunning", "Inna instancja Relhax Manager jest uruchomiona");
            french.Add("anotherInstanceRunning", "Une autre instance de Relhax Directeur est en cours d`éxecution");
            russian.Add("anotherInstanceRunning", "Запущен ещё один процесс Relhax Manager");

            english.Add("closeInstanceRunningForUpdate", "Please close ALL running instances of the Relhax Manager before we can go on and update.");
            german.Add("closeInstanceRunningForUpdate", "Bitte schließe ALLE laufenden Instanzen des Relhax Managers bevor wir fortfahren und aktualisieren können.");
            polish.Add("closeInstanceRunningForUpdate", "Proszę zamknąć WSZYSTKIE działające instancje Relhax Modpack przed dalszym procesem aktualizacji.");
            french.Add("closeInstanceRunningForUpdate", "Merci de fermé toutes les instances du modpack relhax avant que nous puissions procéder à la mise à jour");
            russian.Add("closeInstanceRunningForUpdate", "Пожалуйста, закройте ВСЕ запущенные процессы Relhax Manager перед тем, как мы сможем продолжить работу и обновление.");


            //Componet: 
            //
            english.Add("skipUpdateWarning", "WARNING: You are skipping updating. Database Compatability is not guarenteed");
            german.Add("skipUpdateWarning", "WARNUNG: Sie überspringen die Aktualisierung. Datenbankkompatibilität ist nicht garantiert");
            polish.Add("skipUpdateWarning", "OSTRZEŻENIE: Pomijasz aktualizację! Może wystąpić niezgodność wersji.");
            french.Add("skipUpdateWarning", "ATTENTION: Vous ignorez la mise à jour. Compatibilité de la base de données non garanti ");
            russian.Add("skipUpdateWarning", "ВНИМАНИЕ: Вы пропустили обновление. Совместимость базы данных не гарантирована.");

            //Componet: 
            //
            english.Add("patchDayMessage", "The modpack is curretly down for patch day testing and mods updating. Sorry for the inconvience. If you are a database manager, please add the command arguement");
            german.Add("patchDayMessage", "Das Modpack ist zur Zeit für Patch-Tag-Tests und das Updaten von Mods nicht erreichbar. Entschuldige die Unannehmlichkeiten." +
                " Wenn Sie ein Datenbankmanager sind, fügen Sie bitte das Befehlsargument hinzu");
            polish.Add("patchDayMessage", "Paczka nie działa ze względu na testy i aktualizację modyfikacji. Przepraszamy za utrudnienia. Jeśli zarządzasz bazą danych, proszę dodać odpowiednią komendę");
            french.Add("patchDayMessage", "Le pack mod est actuellement indisponible aujourd'hui pour tester et mettre à jour les mods. Désolé pour le dérangement." +
                " Si vous êtes un gestionnaire de base de données, ajoutez l'argument de commande.");
            russian.Add("patchDayMessage", "В настоящее время модпак отключён в связи с выходом патча, как и обновлений модов. Приносим извинения за неудобства." +
                "Если вы ответственны непосредственно за базу данных, то добавьте аргумент командной строки");

            //Componet: 
            //
            english.Add("configNotExist", "ERROR: {0} does NOT exist, loading in regular mode");
            german.Add("configNotExist", "FEHLER: {0} existiert nicht, lädt im regulären Modus");
            polish.Add("configNotExist", "BŁĄD: {0} nie istnieje, ładowanie podstawowego trybu");
            french.Add("configNotExist", "ERREUR: {0} n'existe pas, chargement en mode normal");
            russian.Add("configNotExist", "ОШИБКА: {0} НЕ существует, запуск в обычном режиме");

            //Componet: 
            //
            english.Add("autoAndClean", "ERROR: clean installation is set to false. You must set this to true and restart the application for auto install to work. Loading in regular mode.");
            german.Add("autoAndClean", "FEHLER: Die saubere Installation ist abgewählt/deaktiviert. Du musst diese Option auswählen und die Anwendung für die automatische" +
                " Installation neu starten, damit sie funktioniert. Lädt im regulären Modus.");
            polish.Add("autoAndClean", "BŁĄD: wyłączono czystą instalację. Musisz ją włączyć i ponownie uruchomić aplikację, by automatyczna instalacja zadziałała. Ładowanie w trybie podstawowym.");
            french.Add("autoAndClean", "ERREUR: Installation propre est désactivé. Vous devez sélectionner ceci et redémarrer l'application pour l'installation automatique. Chargement en mode normal");
            russian.Add("autoAndClean", "ОШИБКА: не используется режим чистой установки. Вы должны включить его и перезапустить приложение для работы автоматической установки. Запуск в обычном режиме.");

            //Componet: 
            //
            english.Add("autoAndFirst", "ERROR: First time loading cannot be an auto install mode, loading in regular mode");
            german.Add("autoAndFirst", "FEHLER: Erstmaliges Laden kann kein automatischer Installationsmodus sein, lade im regulären Modus");
            polish.Add("autoAndFirst", "BŁĄD: Pierwsze ładowanie nie może być automatyczną instalacją, ładowanie w trybie podstawowym");
            french.Add("autoAndFirst", "ERREUR: Le premier lancement ne peut pas être un mode d'installation automatique, chargement en mode normal");
            russian.Add("autoAndFirst", "ОШИБКА: Первый запуск не может быть произведён в режиме автоматической установкой, запуск в обычном режиме.");

            //Componet: 
            //
            english.Add("confirmUninstallHeader", "Confirmation");
            german.Add("confirmUninstallHeader", "Bestätigung");
            polish.Add("confirmUninstallHeader", "Potwierdź");
            french.Add("confirmUninstallHeader", "Confirmation");
            russian.Add("confirmUninstallHeader", "Подтверждение");

            //Componet: 
            //
            english.Add("confirmUninstallMessage", "Confirm you wish to uninstall mods from WoT installation\n\n{0}\n\nUsing uninstall method '{1}'?");
            german.Add("confirmUninstallMessage", "Bitte bestätige das du alle Mods von Deinem WoT deinstalliert haben möchtest\n\n{0}\n\nVerwendung von Deinstallationsmethode '{1}'?");
            polish.Add("confirmUninstallMessage", "Potwierdź usunięcie modyfikacji\n\n{0}\n\nPotwierdź metodę '{1}'");
            french.Add("confirmUninstallMessage", "Confirmer que vous voulez désinstaller les mods du dossier WoT\n\n{0}\n\nUsing la méthode de désinstallation '{1}'?");
            russian.Add("confirmUninstallMessage", "Подтвердите необходимость удалить моды для WoT в этой папке: \n\n{0}\n\nИспользуем метод '{1}'?");

            //Componet: 
            //
            english.Add("uninstallingText", "Uninstalling...");
            german.Add("uninstallingText", "Deinstalliere...");
            polish.Add("uninstallingText", "Deinstalacja w toku...");
            french.Add("uninstallingText", "Désinstallation...");
            russian.Add("uninstallingText", "Удаление...");

            //Component:
            //progress message
            english.Add("uninstallingFile", "Uninstalling file");
            german.Add("uninstallingFile", "Deinstalliere datei");
            polish.Add("uninstallingFile", "Odinstalowanie pliku");
            french.Add("uninstallingFile", "Désinstallation du fichier");
            russian.Add("uninstallingFile", "Удаляется файл");

            //Component: uninstallfinished messagebox
            //
            english.Add("uninstallFinished", "Uninstallation of mods finished.");
            german.Add("uninstallFinished", "Deinstallation der mods beendet.");
            polish.Add("uninstallFinished", "Deinstalacja (modyfikacji) zakończona");
            french.Add("uninstallFinished", "Désinstallation des mods terminé");
            russian.Add("uninstallfinished", "Удаление модов завершено.");

            //Componet: 
            //
            english.Add("specialMessage1", "If you are seeing this, it means that you have a specific computer configuration that is affected by a bug I can't replicate on my developer system." +
                " It's harmless, but if you could send your relHaxLog to me I can fix it and you can stop seeing this message");
            german.Add("specialMessage1", "Wenn Du dies siehst, bedeutet dies, dass Du eine bestimmte Computer-Konfiguration hast, die von einem Fehler betroffen ist, den ich nicht auf meinem" +
                " Entwicklersystem replizieren kann. Es ist harmlos, aber wenn du dein relHaxLog an mich schicken könntest, kann ich es beheben und du wirst diese Nachricht zukuenftig nicht mehr sehen");
            polish.Add("specialMessage1", "Jeśli to widzisz, to znaczy, że masz specificzną konfigurację komputera afektowany przez bug, który nie mogę kopiować na moim systemie. Jest nieszkodliwy," +
                " ale jeśli możesz mi przesłać relHaxLog to postaram się naprawić błąd, abyś nie widział tej wiadomości w przyszłości");
            french.Add("specialMessage1", "Si vous voyez ceci, cela signifie que vous avez une configuration d'ordinateur spécifique qui est affectée par un bug que je ne peux pas répliquer sur mon" +
                " système de développeur. Ce n'est pas grave. Si vous pouvez envoyer votre relHaxLog, je peux le réparer et vous pouvez arrêter de voir ce message.");
            russian.Add("specialMessage1", "Если вы видите это, то это означает, что у вас особая конфигурация ПК, подверженная багу, не воспроизводимому на моей системе." +
                " Это не страшно, но если вы мне отправите ваш relHaxLog, то я могу исправить этот баг и вы больше не увидите это сообщение.");

            //Componet: 
            //
            english.Add("extractionErrorMessage", "Error deleting the folder res_mods or mods. Either World of Tanks is running or your file and folder security permissions are incorrect");
            german.Add("extractionErrorMessage", "Fehler beim Löschen des Ordners res_mods oder Mods. Entweder World of Tanks läuft oder Ihre Datei- und Ordnersicherheitsberechtigungen sind falsch");
            polish.Add("extractionErrorMessage", "Błąd usuwania folderu res_mods lub mods. Albo World of Tanks jest uruchomione, albo twój plik i folder mają nieprawidłowe zabezpieczenia dostępu");
            french.Add("extractionErrorMessage", "Erreur lors de la supression du dossier res_mods ou un/plusieur mods. Sois que World of Tanks est en cours d`éxecution ou les permissions de sécuriter sont incorrect.");
            russian.Add("extractionErrorMessage", "Возникла ошибка при удалении папки res_mods или mods. Возможно, запущен World of Tanks или неверно настроены разрешения к папкам и файлам.");

            //Componet: 
            //
            english.Add("extractionErrorHeader", "Error");
            german.Add("extractionErrorHeader", "Fehler");
            polish.Add("extractionErrorHeader", "Błąd");
            french.Add("extractionErrorHeader", "Erreur");
            russian.Add("extractionErrorHeader", "Ошибка");

            //Componet: 
            //
            english.Add("deleteErrorHeader", "Close out of folders");
            german.Add("deleteErrorHeader", "Ausschliessen von Ordnern");
            polish.Add("deleteErrorHeader", "zamknij foldery");
            french.Add("deleteErrorHeader", "Fermez les dossiers");
            russian.Add("deleteErrorHeader", "Закройте папки");
            
            //Componet: 
            //
            english.Add("deleteErrorMessage", "Please close all explorer windows in mods or res_mods (or deeper), and click ok to continue.");
            german.Add("deleteErrorMessage", "Bitte schließen Sie alle Explorer-Fenster in Mods oder res_mods (oder Unterordner), und klicken Sie auf OK, um fortzufahren.");
            polish.Add("deleteErrorMessage", "Proszę zamknij folder mods lub res_mods (lub podfoldery), a następnie kliknij kontynuację.");
            french.Add("deleteErrorMessage", "Veuillez fermer les fenêtre res_mods ou mods (Ou tout sous-dossiers) et cliquez Ok pour continuer");
            russian.Add("deleteErrorMessage", "Закройте окна проводника, в которых открыты mods или res_mods (или глубже), и нажмите OK, чтобы продолжить.");

            //Componet: 
            //
            english.Add("noUninstallLogMessage", "The log file containg the installed files list (installedRelhaxFiles.log) does not exist. Would you like to remove all mods instead?");
            german.Add("noUninstallLogMessage", "Die Protokolldatei mit der Liste der installierten Dateien (installedRelhaxFiles.log) existiert nicht. Möchtest Du alle Mods stattdessen entfernen?");
            polish.Add("noUninstallLogMessage", "Plik logów zawierający listę instalacyjną (installedRelhaxFiles.log) nie istnieje. Czy chciałbyś usunąć modyfikacje?");
            french.Add("noUninstallLogMessage", "Le ficher log contenant la liste des fichiers installé (installedRelhaxFiles.log) n'existe pas. Voulez vous supprimez tout les mods?");
            russian.Add("noUninstallLogMessage", "Файл со списком установленных файлов (installedRelhaxFiles.log) не существует. Хотите удалить все установленные моды в таком случае?");

            //Componet: 
            //
            english.Add("noUninstallLogHeader", "Remove all mods");
            german.Add("noUninstallLogHeader", "Entferne alle Mods");
            polish.Add("noUninstallLogHeader", "Usuń wszystkie modyfikacje");
            french.Add("noUninstallLogHeader", "Supprimer tout les mods");
            russian.Add("noUninstallLogHeader", "Удалить все моды");

            //Component: appDataFolderError
            //If the appDataFolder is not parsed properly
            english.Add("appDataFolderError", "The app data folder for WoT was not found. Clearing WoT cache will be skipped. Please report this to the developer team.");
            german.Add("appDataFolderError", "Der App-Datenordner für WoT wurde nicht gefunden. Das Löschen von WoT-Cache wird übersprungen. Bitte melden Sie dies dem Entwicklerteam.");
            polish.Add("appDataFolderError", "Nie znaleziono foderu app data dla WoT. Czyszczenie folderu cache zostanie pominięte. Prosimy zgłosić problem naszym deweloperom.");
            french.Add("appDataFolderError", "Le dossier App Data pour WoT n'as pas pus être trouvé. Nettoyage du cache vas être ignoré. Veuillez avertir l`équipe de développement");
            russian.Add("appDataFolderError", "Не найдена папка с данными World of Tanks. Очистка кэша будет пропущена. Сообщите об этом команде разработчиков.");

            //Component: clearCacheCB
            //
            english.Add("clearCacheCB", "Clear WoT cache data");
            german.Add("clearCacheCB", "Cache-Daten für WoT löschen");
            polish.Add("clearCacheCB", "Usuń dane WoT cache");
            french.Add("clearCacheCB", "Nettoyer le dossier de Cache WoT");
            russian.Add("clearCacheCB", "Очистить кэш World of Tanks");

            //Component: clearCachCBDescription
            //
            english.Add("clearCacheCBDescription", "Clear the WoT cache app data directory. Performs the same task as the similar option that was in OMC.");
            german.Add("clearCacheCBDescription", "Löschen Sie das WoT-Cache-App-Datenverzeichnis. Führt die gleiche Aufgabe wie die ähnliche Option aus, die in OMC war.");
            polish.Add("clearCacheCBDescription", "Usuń dane aplikacji z lokacji WoT cache. Działa na podobnej zasadzie, jak kiedyś opcja z paczki OMC.");
            french.Add("clearCacheCBDescription", "Nettoyer le dossier cache WoT. Effectue la même tâche que l'option similaire qui était dans OMC.");
            russian.Add("clearCachCBDescription", "Очистить папку кэша World of Tanks. Операция аналогична соответствующей опции, присутствовавшей в OMC.");

            //Component: clearLogFilesDescription
            //
            english.Add("clearLogFilesCBDescription", "Clear the WoT log files, (python.log), as well as xvm log files (xvm.log) and pmod log files (pmod.log)");
            german.Add("clearLogFilesCBDescription", "Löschen der WoT Protokolldatei, sowie XVM und PMOD Protokolldatei");
            polish.Add("clearLogFilesCBDescription", "Wyczyść logi WoTa (python.log), XVM'a (xvm.log) i pmod'ów (pmod.log).");
            french.Add("clearLogFilesCBDescription", "Effacez les fichiers logs WoT (python.log), ainsi que les fichiers logs xvm (xvm.log) et les fichiers logs pmod (pmod.log)");
            russian.Add("clearLogFilesCBDescription", "Очистка логов World of Tanks (python.log), XVM (xvm.log) и PMOD (pmod.log).");

            //Component: EnableColorChangeDefaultCBDescription
            //
            english.Add("EnableColorChangeDefaultCBDescription", "Enable the changing of colors when toggling the selection of a mod or config.");
            german.Add("EnableColorChangeDefaultCBDescription", "Die Farbe ändert sich, wenn man eine Auswahl getroffen hat");
            polish.Add("EnableColorChangeDefaultCBDescription", "Włącz zmianê kolorów podczas zmiany wyboru modyfikacji i ustawieñ.");
            french.Add("EnableColorChangeDefaultCBDescription", "Activer le changement de les couleurs lors de la selection d'un mod ou d'une config");
            russian.Add("EnableColorChangeDefaultCBDescription", "Включить замену цветов при выборе мода или конфигурации");

            //Component: EnableColorChangeDefaultV2CBDescription
            //
            english.Add("EnableColorChangeDefaultV2CBDescription", "Enable the changing of colors when toggling the selection of a mod or config.");
            german.Add("EnableColorChangeDefaultV2CBDescription", "Die Farbe ändert sich, wenn man eine Auswahl getroffen hat");
            polish.Add("EnableColorChangeDefaultV2CBDescription", "Włącz zmianê kolorów podczas zmiany wyboru modyfikacji i ustawieñ.");
            french.Add("EnableColorChangeDefaultV2CBDescription", "Activer le changement de les couleurs lors de la selection d'un mod ou d'une config");
            russian.Add("EnableColorChangeDefaultV2CBDescription", "Включить замену цветов при выборе мода или конфигурации");

            //Component: EnableColorChangeLegacyCBDescription
            //
            english.Add("EnableColorChangeLegacyCBDescription", "Enable the changing of colors when toggling the selection of a mod or config.");
            german.Add("EnableColorChangeLegacyCBDescription", "Die Farbe ändert sich, wenn man eine Auswahl getroffen hat");
            polish.Add("EnableColorChangeLegacyCBDescription", "Włącz zmianê kolorów podczas zmiany wyboru modyfikacji i ustawieñ.");
            french.Add("EnableColorChangeLegacyCBDescription", "Activer le changement de les couleurs lors de la selection d'un mod ou d'une config");
            russian.Add("EnableColorChangeLegacyCBDescription", "Включить замену цветов при выборе мода или конфигурации");

            //Component: notifyIfSameDatabaseCBDescription
            //
            english.Add("notifyIfSameDatabaseCBDescription", "Notify you if your last installed database version is the same. If so, it means that there is no update to any mods.");
            german.Add("notifyIfSameDatabaseCBDescription", "Dich benachrichtigen: Die letzte verwendete Datenbank ist die selbe, d.h. es gibt keine Aktualisierungen und Veränderungen.");
            polish.Add("notifyIfSameDatabaseCBDescription", "Powiadom, jeśli ostatnia zainstalowana wersja bazy danych jest taka sama. Jeśli tak, to nie ma potrzeby aktualizacji modyfikacji.");
            french.Add("notifyIfSameDatabaseCBDescription", "Avertir si votre dernière version de base de données installée est identique. Si c'est le cas, cela signifie qu'il n'y a pas de mise à jour de mods.");
            russian.Add("notifyIfSameDatabaseCBDescription", "Уведомлять в случае совпадения версий баз данных. Это означает отсутствие обновлений к каким-либо модам.");

            //Component: ShowInstallCompleteWindowCBDescription
            //
            english.Add("ShowInstallCompleteWindowCBDescription", "Show a window upon installation completion with popular operations to perform after modpack installation, such as launching" +
                " the game, going to the xvm website, etc.");
            german.Add("ShowInstallCompleteWindowCBDescription", "Zeigte am Ende der Installation ein Auswahlfenster mit nützlichen Befehlen an, wie: starte das Spiel, gehe zur XVM Webseite, usw ...");
            polish.Add("ShowInstallCompleteWindowCBDescription", "Po zakończeniu instalacji otwórz okno dalszych akcji.");
            french.Add("ShowInstallCompleteWindowCBDescription", "Afficher une fenêtre lors de l'achèvement de l'installation avec des opérations populaires à effectuer après l'installation de Modpack," +
                " telles que le lancement du jeu, le site Web de XVM, etc.");
            russian.Add("ShowInstallCompleteWindowCBDescription", "Показывать окно по окончании установки с частыми действиями после установки модпака (запуск игры, открыть сайт XVM, и т. п.)");

            //Component: ShowInstallCompleteWindowCBDescription
            //
            english.Add("createShortcutsCBDescription", "When selected, it will create shortcut icons on your desktop for mods that are exe files (like WWIIHA configuration)");
            german.Add("createShortcutsCBDescription", "Wenn diese Option aktiviert ist, werden bei der Installation die Verknüpfungen für \"World of Tanks\", \"World of Tanks launcher\" und, wenn bei" +
                " der Installation aktiviert, auch andere Verknüpfungen zu Konfigurationsprogrammen erstellt (z.B. WWIIHA Konfiguration)");
            polish.Add("createShortcutsCBDescription", "Kiedy zaznaczone, utworzone zostaną skróty na pulpicie do modyfikacji z plikami exe (np. konfiguracja WWIIHA)");
            french.Add("createShortcutsCBDescription", "Une fois sélectionné, L'installation créera des icônes de raccourci sur votre bureau pour les mods qui ont des fichiers .exe (comme la configuration WWIIHA)");
            russian.Add("createShortcutsCBDescription", "Если выбрано, то будут созданы ярлыки на рабочем столе для модов, являющимися EXE-файлами (как WWIIHA)");

            //Component: InstantExtractionCBDescription
            //
            english.Add("InstantExtractionCBDescription", "When enabled, the installer will extract a zip file as soon as it is downloaded, rather than waiting for every zip file to be downloaded" +
                " before extraction. Recommended for those with Solid State Drives (SSD) only.");
            german.Add("InstantExtractionCBDescription", "Wenn aktiviert, der Installer wird die Zip-Dateien sofort nach dem Download entpacken und nicht erst auf das Herunterladen aller Dateien warten" +
                " bevor mit dem Entpacken begonnen wird. Nur empfohlen für Besitzer von SSD Festplatten (Solid State Drives).");
            polish.Add("InstantExtractionCBDescription", "Wypakowywanie pobranych plików zip w tle podczas procesu ściągania paczek. Rekomendowany jedynie dla dysków SSD.");
            french.Add("InstantExtractionCBDescription", "Quand activé , l'installateur vas extraire un fichier zip dès qu'il est télécharger , au lieu d'attendre que chaque fichier zip soit" +
                " télécharger pour l'extraction . Recommandé pour les processeurs de SSD seulement.");
            russian.Add("InstantExtractionCBDescription", "Если включено, то установщик будет распаковывать ZIP-архив сразу после скачивания, вместо того, чтобы ждать окончания загрузки " +
                "всех файлов перед распаковкой. Рекомендуется для владельцев компьютеров, в которых только SSD.");

            //Component: SuperExtractionCBDescription
            //
            english.Add("SuperExtractionCBDescription", "When enabled, the installer will use a parallel extraction method. It will extract multiple zip files at the same time," +
                " reducing install time. For SSD drives ONLY.");
            german.Add("SuperExtractionCBDescription", "Wenn aktiviert, wird der Installer den parallelen Entpack-Modus verwenden. Er wird mehrere Zip-Dateien gleichzeitig entpacken" +
                " und dadurch die Installationszeit reduziert. Nur für SSD Festplatten.");
            polish.Add("SuperExtractionCBDescription", "Metoda wypakowywania równoległego. Nastąpi wypakowywanie wielu plików zip jednocześnie, by skrócić czas instalacji." +
                " Jedynie dla dysków SSD.");// I always skip 'When enabled'...
            french.Add("SuperExtractionCBDescription", "Lorsqu'il est activé, le programme d'installation utilise une méthode d'extraction parallèle. Il va extraire plusieurs fichiers" +
                " zip en même temps, réduisant ainsi le temps d'installation. Pour les disques SSD SEULEMENT.");
            russian.Add("SuperExtractionCBDescription", "Если включено, то установщик будет использовать метод параллельной распаковки. Будет извлекаться несколько ZIP-архивов одновременно," +
                " снижая время установки. ТОЛЬКО ДЛЯ SSD ДИСКОВ!");

            //Component: DefaultUninstallModeRBDescription
            //
            english.Add("DefaultUninstallModeRBDescription", "Default Uninstall will remove all files in the game's mod directories, including shortcuts and appdata cache files.");
            german.Add("DefaultUninstallModeRBDescription", "Die Standard Deinstallation wird alle Dateien in den Mod-Verzeichnissen des Spieles löschen, inklusive der Verknüpfungen und Dateien im 'AppData' Speicher.");
            polish.Add("DefaultUninstallModeRBDescription", "Domyślna deinstalacja usunie wszystkie pliki w folderze modyfikacji i pliki z nimi związane, włączając skróty i pliki cache aplikacji.");
            french.Add("DefaultUninstallModeRBDescription", "La méthode de désinstallation par défaut vas supprimer tout les fichiers dans le dossier du jeu, incluant les raccourcies et le fichers de cache appdata");
            russian.Add("DefaultUninstallModeRBDescription", "Обычная деинсталляция удалит все моды, включая ярлыки и кэш в AppData.");

            //Component: CleanUninstallModeRBDescription
            //
            english.Add("CleanUninstallModeRBDescription", "Quick Uninstall will only remove files in the game's mod directories. It does not remove modpack created shortcuts or appdata cache files.");
            german.Add("CleanUninstallModeRBDescription", "Die schnelle Deinstallation wird nur Dateien in den Mod-Verzeichnissen der Spieles löschen. Es werden keine vom ModPack erstellten Verknüpfungen oder Dateien im 'AppData' Speicher gelöscht.");
            polish.Add("CleanUninstallModeRBDescription", "Szybka deinstalacja usunie tylko pliki w folderze modyfikacji. Nie usunie skrótów i plików cache związanych z modpackiem.");
            french.Add("CleanUninstallModeRBDescription", "La méthode de désinstallation rapide vas uniquement supprimer les fichiers dans le dossier \"mod\" du jeu. Ceci ne supprimeras pas les raccourcis ou les fichiers de cache appdata créé par le modpack");
            russian.Add("CleanUninstallModeRBDescription", "Быстрая деинсталляция удалит только моды, оставив ярлыки, созданные модпаком, и кэш в AppData.");

            //Component: ExportModeCBDescription
            //Explaiing the export mode
            english.Add("ExportModeCBDescription", "Export mode will allow you to select a folder and WoT version you wish to export your mods installation to. For advanced users only." +
                "Note it will NOT: Unpack game xml files, patch files (provided from the game), or create the atlas files. Instructions can be found in the export directory.");
            german.Add("ExportModeCBDescription", "Der Export-Modus ermöglicht es Ihnen, einen Ordner und WoT-Version zu wählen, in die Sie Ihre Mods-Installation exportieren möchten." +
                " Nur für fortgeschrittene Benutzer. Bitte beachten: es werden KEINE: Spiel-XML-Dateien entpackt und nicht modifiziert oder Atlas Dateien erstellt (jeweils aus dem Spiel" +
                " bereitgestellt). Anweisungen dazu finden Sie im Export-Verzeichnis.");
            polish.Add("ExportModeCBDescription", "Tryb wyboru ścieżki wypakowania pozwala na wybór folderu i wersji WoT, do których chcesz zainstalować modyfikacje. Tylko dla zaawansowanych użytkowników." +
                " Tryb: nie rozpakuje plików gry xml, plików patchy (zapewnianych przez grę), oraz niestworzy plików atlasu. Instrukcje można znaleźć pod ścieżką wypakowania.");
            french.Add("ExportModeCBDescription", "Le mode Export vous permettra de sélectionner un dossier et la version de WoT vers lesquels vous souhaitez exporter votre installation" +
                " de mods. Pour les utilisateurs avancés, notez que l'installation ne fera pas: Déballez " +
                "les fichiers xml du jeu, corrigez les fichiers (fournis depuis le jeu) ou créez l'atlas. Les instructions peuvent être trouvées dans le répertoire d'exportation.");
            russian.Add("ExportModeCBDescription", "Режим экспорта позволит выбрать папку для экспорта установленных модификаций в игру. Только для продвинутых пользователей." +
                "Учтите, что эта опция НЕ распакует XML-файлы игры, патчить их или создавать атласы. Инструкции находятся в папке экспорта.");    

            //Component: DiagnosticUtilitiesButton
            //
            english.Add("DiagnosticUtilitiesButton", "Diagnostic utilities");
            german.Add("DiagnosticUtilitiesButton", "Diagnosedienstprogramme");
            polish.Add("DiagnosticUtilitiesButton", "Narzędzia diagnostyczne");
            french.Add("DiagnosticUtilitiesButton", "Utilitaires de diagnostic");
            russian.Add("DiagnosticUtilitiesButton", "Диагностика");

            //Component: DatabaseVersionLabel
            //
            english.Add("DatabaseVersionLabel", "Latest Database");
            german.Add("DatabaseVersionLabel", "Datenbank");
            polish.Add("DatabaseVersionLabel", "Baza danych");
            french.Add("DatabaseVersionLabel", "Base de donnés");
            russian.Add("DatabaseVersionLabel", "Последняя БД");

            //Component: UninstallModeGroupBox
            //
            english.Add("UninstallModeGroupBox", "Uninstall Mode");
            german.Add("UninstallModeGroupBox", "Deinstallationsmodus");
            polish.Add("UninstallModeGroupBox", "Tryb Deinstalacji");
            french.Add("UninstallModeGroupBox", "Mode de désinstallation");
            russian.Add("UninstallModeGroupBox", "Режим деинсталляции");

            //Componet: FontLayoutPanelDescription
            //
            english.Add("FontLayoutPanelDescription", "Select a scale mode to use.");
            german.Add("FontLayoutPanelDescription", "Wähle einen Skalierungsgrad.");
            polish.Add("FontLayoutPanelDescription", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("FontLayoutPanelDescription", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("FontLayoutPanelDescription", "Выберите режим масштабирования");

            //Componet: fontSize100Description
            //
            english.Add("fontSize100Description", "Select a scale mode to use.");
            german.Add("fontSize100Description", "Wähle einen Skalierungsgrad.");
            polish.Add("fontSize100Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("fontSize100Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("fontSize100Description", "Выберите режим масштабирования");

            //Componet: fontSize125Description
            //
            english.Add("fontSize125Description", "Select a scale mode to use.");
            german.Add("fontSize125Description", "Wähle einen Skalierungsgrad.");
            polish.Add("fontSize125Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("fontSize125Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("fontSize125Description", "Выберите режим масштабирования");

            //Componet: fontSize175Description
            //
            english.Add("fontSize175Description", "Select a scale mode to use.");
            german.Add("fontSize175Description", "Wähle einen Skalierungsgrad.");
            polish.Add("fontSize175Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("fontSize175Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("fontSize175Description", "Выберите режим масштабирования");

            //Componet: fontSize225Description
            //
            english.Add("fontSize225Description", "Select a scale mode to use.");
            german.Add("fontSize225Description", "Wähle einen Skalierungsgrad.");
            polish.Add("fontSize225Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("fontSize225Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("fontSize225Description", "Выберите режим масштабирования");

            //Componet: fontSize275Description
            //
            english.Add("fontSize275Description", "Select a scale mode to use.");
            german.Add("fontSize275Description", "Wähle einen Skalierungsgrad.");
            polish.Add("fontSize275Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("fontSize275Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("fontSize275Description", "Выберите режим масштабирования");

            //Componet: DPIAUTODescription
            //
            english.Add("DPIAUTODescription", "Select a scale mode to use.");
            german.Add("DPIAUTODescription", "Wähle einen Skalierungsgrad.");
            polish.Add("DPIAUTODescription", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("DPIAUTODescription", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("DPIAUTODescription", "Выберите режим масштабирования");

            //Componet: DPI100Description
            //
            english.Add("DPI100Description", "Select a scale mode to use.");
            german.Add("DPI100Description", "Wähle einen Skalierungsgrad.");
            polish.Add("DPI100Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("DPI100Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("DPI100Description", "Выберите режим масштабирования");

            //Componet: DPI125Description
            //
            english.Add("DPI125Description", "Select a scale mode to use.");
            german.Add("DPI125Description", "Wähle einen Skalierungsgrad.");
            polish.Add("DPI125Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("DPI125Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("DPI125Description", "Выберите режим масштабирования");

            //Componet: DPI175Description
            //
            english.Add("DPI175Description", "Select a scale mode to use.");
            german.Add("DPI175Description", "Wähle einen Skalierungsgrad.");
            polish.Add("DPI175Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("DPI175Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("DPI175Description", "Выберите режим масштабирования");

            //Componet: DPI225Description
            //
            english.Add("DPI225Description", "Select a scale mode to use.");
            german.Add("DPI225Description", "Wähle einen Skalierungsgrad.");
            polish.Add("DPI225Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("DPI225Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("DPI225Description", "Выберите режим масштабирования");

            //Componet: DPI275Description
            //
            english.Add("DPI275Description", "Select a scale mode to use.");
            german.Add("DPI275Description", "Wähle einen Skalierungsgrad.");
            polish.Add("DPI275Description", "Wybierz tryb skali, który ma zostać użyty.");
            french.Add("DPI275Description", "Sélectionnez un mode d'échelle à utiliser.");
            russian.Add("DPI275Description", "Выберите режим масштабирования");

            //Componet: selectionView_MouseEnter
            //
            english.Add("selectionView_MouseEnter", "Select a mod selection list view.");
            german.Add("selectionView_MouseEnter", "wähle eine der Listenansichten.");
            polish.Add("selectionView_MouseEnter", "Wybierz listę wyboru modyfikacji.");
            french.Add("selectionView_MouseEnter", "Sélectionnez une vue de liste de sélection de mod.");
            russian.Add("selectionView_MouseEnter", "Выберите вид списка модов");

            //Componet: LanguageComboBoxDescription
            //
            english.Add("LanguageComboBoxDescription", "Select your preferred language.");
            german.Add("LanguageComboBoxDescription", "wähle Deine bevorzugte Sprache");
            polish.Add("LanguageComboBoxDescription", "Wybierz preferowany język.");
            french.Add("LanguageComboBoxDescription", "Sélectionnez votre langue préféré");
            russian.Add("LanguageComboBoxDescription", "Выберите желаемый язык");

            //Componet: fontSizeGB
            //
            english.Add("fontSizeGB", "Scaling Mode");
            german.Add("fontSizeGB", "Skalierungsmodus");
            polish.Add("fontSizeGB", "Tryb skalowania");
            french.Add("fontSizeGB", "Mode d'échelle");
            russian.Add("fontSizeGB", "Режим масштабирования");

            //Componet: expandNodesDefault
            //
            english.Add("expandNodesDefault", "Expand all");
            german.Add("expandNodesDefault", "Alle erweitern");
            polish.Add("expandNodesDefault", "Rozwiń wszystkie");
            french.Add("expandNodesDefault", "Développer tout");
            russian.Add("expandNodesDefault", "Раскрыть все");

            //Componet: expandNodesDefault2
            //
            english.Add("expandNodesDefault2", "Expand all");
            german.Add("expandNodesDefault2", "Alle erweitern");
            polish.Add("expandNodesDefault2", "Rozwiń wszystkie");
            french.Add("expandNodesDefault2", "Développer tout");
            russian.Add("expandNodesDefault2", "Раскрыть все");

            //Component: expandNodesDefaultDescription
            //
            english.Add("expandNodesDefaultDescription", "Select this to have all options automatically expand. It applies for the Legacy Selection only.");
            german.Add("expandNodesDefaultDescription", "Erweitere alle Einträge auf allen Registerkarten automatisch. Nur bei Ansicht als Baumstruktur.");
            polish.Add("expandNodesDefaultDescription", "Zaznacz to, aby wszystkie opcje zostały automatycznie rozwinięte. Dotyczy tylko opcji Legacy Selection.");
            french.Add("expandNodesDefaultDescription", "Sélectionnez cette option pour que toutes les options s'élargis automatiquement. S'applique uniquement à la Sélection Legacy.");
            russian.Add("expandNodesDefaultDescription", "Выберите этот пункт для автоматического раскрытия всех списков. Применимо только для legacy.");

            //Component: EnableBordersDefaultCB
            //
            english.Add("EnableBordersDefaultCB", "Enable borders");
            german.Add("EnableBordersDefaultCB", "Einrahmen");
            polish.Add("EnableBordersDefaultCB", "Włącz granice");
            french.Add("EnableBordersDefaultCB", "Activer les bordures");
            russian.Add("EnableBordersDefaultCB", "Включить границы");

            //Component: EnableBordersDefaultV2CB
            //
            english.Add("EnableBordersDefaultV2CB", "Enable borders");
            german.Add("EnableBordersDefaultV2CB", "Einrahmen");
            polish.Add("EnableBordersDefaultV2CB", "Włącz granice");
            french.Add("EnableBordersDefaultV2CB", "Activer les bordures");
            russian.Add("EnableBordersDefaultV2CB", "Включить границы");

            //Component: EnableBordersLegacyCB
            //
            english.Add("EnableBordersLegacyCB", "Enable borders");
            german.Add("EnableBordersLegacyCB", "Einrahmen");
            polish.Add("EnableBordersLegacyCB", "Włącz granice");
            french.Add("EnableBordersLegacyCB", "Activer les bordures");
            russian.Add("EnableBordersLegacyCB", "Включить границы");

            //Component: EnableBordersDefaultCBDescription
            //
            english.Add("EnableBordersDefaultCBDescription", "Enable the black borders around each mod and config sublevel.");
            german.Add("EnableBordersDefaultCBDescription", "Jede Auswahl schwarz einrahmen");
            polish.Add("EnableBordersDefaultCBDescription", "Włącz czarne obramowanie modyfikacji i opcji konfiguracji");
            french.Add("EnableBordersDefaultCBDescription", "Activer les bordures noires autour de chaque mod et selections de configuration.");
            russian.Add("EnableBordersDefaultCBDescription", "Включить показ чёрных рамок вокруг наименования каждого мода и конфигурации.");

            //Component: EnableBordersDefaultCBDescription
            //
            english.Add("EnableBordersDefaultV2CBDescription", "Enable the black borders around each mod and config sublevel.");
            german.Add("EnableBordersDefaultV2CBDescription", "Jede Auswahl schwarz einrahmen");
            polish.Add("EnableBordersDefaultV2CBDescription", "Włącz czarne obramowanie modyfikacji i opcji konfiguracji");
            french.Add("EnableBordersDefaultV2CBDescription", "Activer les bordures noires autour de chaque mod et selections de configuration.");
            russian.Add("EnableBordersDefaultV2CBDescription", "Включить показ чёрных рамок вокруг наименования каждого мода и конфигурации.");

            //Component: EnableBordersLegacyCBDescription
            //
            english.Add("EnableBordersLegacyCBDescription", "Enable the black borders around each mod and config sublevel.");
            german.Add("EnableBordersLegacyCBDescription", "Jede Auswahl schwarz einrahmen");
            polish.Add("EnableBordersLegacyCBDescription", "Włącz czarne obramowanie modyfikacji i opcji konfiguracji");
            french.Add("EnableBordersLegacyCBDescription", "Activer les bordures noires autour de chaque mod et selections de configuration.");
            russian.Add("EnableBordersLegacyCBDescription", "Включить показ чёрных рамок вокруг наименования каждого мода и конфигурации.");

            //Component: moveOutOfTanksLocation
            //
            english.Add("moveOutOfTanksLocation", "The modpack can not be run from the World_of_Tanks directory. Please move the application and try again.");
            german.Add("moveOutOfTanksLocation", "Das Modpack kann nicht aus dem World_of_Tanks Verzeichnis laufen. Bitte verschiebe die Anwendung in ein anderes Verzeichnis und versuchen Sie es erneut.");
            polish.Add("moveOutOfTanksLocation", "Modpack nie może być uruchomiony z katalogu World_of_Tanks. Przenieś aplikację i spróbuj ponownie.");
            french.Add("moveOutOfTanksLocation", "Le Mod pack ne peut pas être éxecuté a partir du dossier de World of Tanks. Veuillez déplacer l`application dans un autre dossier et réessayer");
            russian.Add("moveOutOfTanksLocation", "Модпак не может быть запущен из папки с игрой. Пожалуйста, переместите его в другую папку и попробуйте ещё раз.");

            //Component: Current database is same as last installed database (body)
            //
            english.Add("DatabaseVersionsSameBody", "The database has not changed since your last installation. Therefore there are no updates to your current mods selection." +
                " Continue anyway?");
            german.Add("DatabaseVersionsSameBody", "Die Datenbank  wurde seit Deiner letzten Installation nicht verändert. Daher gibt es keine Aktuallisierungen zu Deinen aktuellen" +
                " Modifikationen. Trotzdem fortfahren?");
            polish.Add("DatabaseVersionsSameBody", "Baza danych nie została zmieniona od ostatniej instalacji, nie ma żadych aktualizacji dla wybranych uprzednio modyfikacji." +
                " Czy kontynuować?");
            french.Add("DatabaseVersionsSameBody", "La base de données n'a pas changé depuis votre dernière installation. Par conséquent, il n'y a pas de mise à jour pour votre sélection" +
                "  de mods. Continuer de toute façon?");
            russian.Add("DatabaseVersionsSameBody", "База данных не менялась с момента последней установки. В то же время не обновлений к выбранным вами модам. Продолжить в любом случае?");

            //Component: Current database is same as last installed database (header)
            //
            english.Add("DatabaseVersionsSameHeader", "Database version is the same");
            german.Add("DatabaseVersionsSameHeader", "Datenbank Version ist identisch");
            polish.Add("DatabaseVersionsSameHeader", "Wersja bazy danych jest taka sama");
            french.Add("DatabaseVersionsSameHeader", "La version de la base de données est la même");
            russian.Add("DatabaseVersionsSameHeader", "Одинаковые версии БД");

            //Componet: 
            //
            english.Add("databaseNotFound", "Database not found at supplied URL");
            german.Add("databaseNotFound", "Datenbank nicht an der angegebenen URL gefunden");
            polish.Add("databaseNotFound", "Nie znaleziono bazy danych pod wskazanym URL");
            french.Add("databaseNotFound", "Base de données introuvable à L'URL fournie  ");
            russian.Add("databaseNotFound", "По запрошенному адресу база данных не найдена");

            //Componet: Mod Selection view Group Box
            //
            english.Add("SelectionViewGB", "Selection View");
            german.Add("SelectionViewGB", "Darstellungsart");
            polish.Add("SelectionViewGB", "Widok wyborów");
            french.Add("SelectionViewGB", "Affichage de sélection");
            russian.Add("SelectionViewGB", "Вид списка");

            //Componet: Mod selection view default (relhax)
            //
            english.Add("SelectionDefault", "Default");
            german.Add("SelectionDefault", "Standard");
            polish.Add("SelectionDefault", "Domyślne");
            french.Add("SelectionDefault", "Normal");
            russian.Add("SelectionDefault", "Стандартный");

            //Componet: Mod selection view default (relhax) [WPF VERSION]
            //
            english.Add("SelectionDefaultV2", "Default V2");
            german.Add("SelectionDefaultV2", "Standard V2");
            polish.Add("SelectionDefaultV2", "Domyślne V2");
            french.Add("SelectionDefaultV2", "Normal V2");
            russian.Add("SelectionDefaultV2", "Стандартный V2");

            //Componet: Mod selection view legacy (OMC)
            //
            english.Add("SelectionLegacy", "OMC Legacy");
            german.Add("SelectionLegacy", "OMC Legacy");
            polish.Add("SelectionLegacy", "OMC Legacy");
            french.Add("SelectionLegacy", "OMC Legacy");
            russian.Add("SelectionLegacy", "OMC Legacy");

            //Componet: Mod selection Description
            //
            english.Add("SelectionLayoutDescription", "Select a mod selection list view mode\nDefault: Relhax list view mode\nLegacy: OMC tree list view mode");
            german.Add("SelectionLayoutDescription", "Anzeigearten und Auswahl der Modifikationen\nStandard: Relhax Listendarstellung\nalternativ: OMC Baumstruktur");
            polish.Add("SelectionLayoutDescription", "Wybierz tryb widoku wyborów modyfikacji\nDomyślnie: Tryb widoku listy RelHax\nSpuścizna: Tryb widoku listy OMC");
            french.Add("SelectionLayoutDescription", "Sélectionnez un style de liste pour la sélection\nNormal: Liste de sélection Relhax\nLegacy: Liste de vue arbre OMC");
            russian.Add("SelectionLayoutDescription", "Выберите вид списка модов\nОбычный: как в Relhax (постранично)\nLegacy: как в OMC (деревом)");

            //Componet: Mod selection Description
            //
            english.Add("SelectionDefaultDescription", "Select a mod selection list view mode\nDefault: Relhax list view mode\nLegacy: OMC tree list view mode");
            german.Add("SelectionDefaultDescription", "Anzeigearten und Auswahl der Modifikationen\nStandard: Relhax Listendarstellung\nalternativ: OMC Baumstruktur");
            polish.Add("SelectionDefaultDescription", "Wybierz tryb widoku wyborów modyfikacji\nDomyślnie: Tryb widoku listy RelHax\nSpuścizna: Tryb widoku listy OMC");
            french.Add("SelectionDefaultDescription", "Sélectionnez un style de liste pour la sélection\nNormal: Liste de sélection Relhax\nLegacy: Liste de vue arbre OMC");
            russian.Add("SelectionDefaultDescription", "Выберите вид списка модов\nОбычный: как в Relhax (постранично)\nLegacy: как в OMC (деревом)");

            //Componet: Mod selection Description
            //
            english.Add("SelectionDefaultV2Description", "Select a mod selection list view mode\nDefault: Relhax list view mode\nLegacy: OMC tree list view mode");
            german.Add("SelectionDefaultV2Description", "Anzeigearten und Auswahl der Modifikationen\nStandard: Relhax Listendarstellung\nalternativ: OMC Baumstruktur");
            polish.Add("SelectionDefaultV2Description", "Wybierz tryb widoku wyborów modyfikacji\nDomyślnie: Tryb widoku listy RelHax\nSpuścizna: Tryb widoku listy OMC");
            french.Add("SelectionDefaultV2Description", "Sélectionnez un style de liste pour la sélection\nNormal: Liste de sélection Relhax\nLegacy: Liste de vue arbre OMC");
            russian.Add("SelectionDefaultV2Description", "Выберите вид списка модов\nОбычный: как в Relhax (постранично)\nLegacy: как в OMC (деревом)");

            //Componet: Mod selection Description
            //
            english.Add("SelectionLegacyDescription", "Select a mod selection list view mode\nDefault: Relhax list view mode\nLegacy: OMC tree list view mode");
            german.Add("SelectionLegacyDescription", "Anzeigearten und Auswahl der Modifikationen\nStandard: Relhax Listendarstellung\nalternativ: OMC Baumstruktur");
            polish.Add("SelectionLegacyDescription", "Wybierz tryb widoku wyborów modyfikacji\nDomyślnie: Tryb widoku listy RelHax\nSpuścizna: Tryb widoku listy OMC");
            french.Add("SelectionLegacyDescription", "Sélectionnez un style de liste pour la sélection\nNormal: Liste de sélection Relhax\nLegacy: Liste de vue arbre OMC");
            russian.Add("SelectionLegacyDescription", "Выберите вид списка модов\nОбычный: как в Relhax (постранично)\nLegacy: как в OMC (деревом)");

            //Componet: Detected client version
            //
            english.Add("detectedClientVersion", "Detected Client version");
            german.Add("detectedClientVersion", "Erkannte Client Version");
            polish.Add("detectedClientVersion", "Wykryta wersja klienta gry");
            french.Add("detectedClientVersion", "Version du client détecté");
            russian.Add("detectedClientVersion", "Обнаруженная версия клиента");

            //Componet: Supported client versions
            //
            english.Add("supportedClientVersions", "Supported Clients");
            german.Add("supportedClientVersions", "Unterstützte Clients");
            polish.Add("supportedClientVersions", "Wspomagane wersje klienta gry");
            french.Add("supportedClientVersions", "Clients supportés");
            russian.Add("supportedClientVersions", "Поддерживаемые версии клиента");

            //Componet: Supported clients notice
            //
            english.Add("supportNotGuarnteed", "This client version is not offically supported. Mods may not work.");
            german.Add("supportNotGuarnteed", "Diese Client Version wird (noch) nicht offiziell unterstützt. Die Mods könnten nicht funktionieren oder sogar Dein World of Tanks beschädigen.");
            polish.Add("supportNotGuarnteed", "Ta wersja klienta gry nie jest oficjalnie wspomagana. Modyfikacje mogą nie działać prawidłowo.");
            french.Add("supportNotGuarnteed", "Ce client n'est pas supporté officiellement. Les mods risque de ne pas fonctionner.");
            russian.Add("supportNotGuarnteed", "Эта версия клиента официально не поддерживается. Моды могут не работать.");

            //Componet: ShowAdvancedSettingsLinkDescription
            //
            english.Add("ShowAdvancedSettingsLinkDescription", "Show the advanced settings window");
            german.Add("ShowAdvancedSettingsLinkDescription", "Erweiterte Einstellungen anzeigen");
            polish.Add("ShowAdvancedSettingsLinkDescription", "Pokaż okno ustawieñ zaawansowanych");
            french.Add("ShowAdvancedSettingsLinkDescription", "Afficher le panneau de configurations avancé");
            russian.Add("ShowAdvancedSettingsLinkDescription", "Показать окно расширенных настроек");

            //Component: FacebookButton
            AddToAll("FacebookButton", "");

            //Component: FacebookButtonDescription
            english.Add("FacebookButtonDescription", "Go to our Facebook page");
            german.Add("FacebookButtonDescription", "Unsere Facebook Seite aufrufen");
            polish.Add("FacebookButtonDescription", "Strona FB");
            french.Add("FacebookButtonDescription", "Page Facebook");
            russian.Add("FacebookButtonDescription", "Перейти на нашу страницу в Facebook");

            //Component: DiscordButton
            AddToAll("DiscordButton", "");

            //Componet: DiscordButtonDescription
            english.Add("DiscordButtonDescription", "Go to Discord server");
            german.Add("DiscordButtonDescription", "Zum Discord Server");
            polish.Add("DiscordButtonDescription", "Serwer Discorda");
            french.Add("DiscordButtonDescription", "Serveur Discord");
            russian.Add("DiscordButtonDescription", "Перейти на наш сервер Discord");

            //Component: TwitterButton
            AddToAll("TwitterButton", "");

            //Component: TwitterButtonDescription
            english.Add("TwitterButtonDescription", "Go to our Twitter page");
            german.Add("TwitterButtonDescription", "Unsere Twitter Seite aufrufen");
            polish.Add("TwitterButtonDescription", "Strona TT");
            french.Add("TwitterButtonDescription", "Page Twitter");
            russian.Add("TwitterButtonDescription", "Перейти на нашу страницу в Twitter");

            //Component: SendEmailButton
            AddToAll("SendEmailButton", "");

            //Component: SendEmailButtonDescription
            english.Add("SendEmailButtonDescription", "Send us an Email");
            german.Add("SendEmailButtonDescription", "Schicke uns eine Email");
            polish.Add("SendEmailButtonDescription", "Przeœlij nam wiadomoœæ e-mail");
            french.Add("SendEmailButtonDescription", "Nous envoyer un Email");
            russian.Add("SendEmailButtonDescription", "Отправить нам письмо по электронной почте");

            //Component: HomepageButton
            AddToAll("HomepageButton", "");

            //Component: HomepageButtonDescription
            english.Add("HomepageButtonDescription", "Visit our Website");
            german.Add("HomepageButtonDescription", "Zu unserer Homepage");
            polish.Add("HomepageButtonDescription", "Odwiedz nasza strone");
            french.Add("HomepageButtonDescription", "Visiter notre site web");
            russian.Add("HomepageButtonDescription", "Посетить наш веб-сайт");

            //Component: DonateButton
            AddToAll("DonateButton", "");

            //Component: DonateButtonDescription
            english.Add("DonateButtonDescription", "Donation for further development");
            german.Add("DonateButtonDescription", "Spende für die Weiterentwicklung");
            polish.Add("DonateButtonDescription", "Dotacja na dalszy rozwój");
            french.Add("DonateButtonDescription", "Donation pour aider au développement");
            russian.Add("DonateButtonDescription", "Поддержать копеечкой для дальнейшей разработки");

            //Component: FindBugAddModButton
            AddToAll("FindBugAddModButton", "");

            //Componet: FindBugAddModButtonDescription
            english.Add("FindBugAddModButtonDescription", "Find a bug? Want a mod added? Report here please!");
            german.Add("FindBugAddModButtonDescription", "Fehler gefunden? Willst Du einen Mod hinzufügen? Bitte hier melden!");
            polish.Add("FindBugAddModButtonDescription", "Znalazłeś błąd? Chcesz dodać mod?");
            french.Add("FindBugAddModButtonDescription", "Trouvé un bug? Recommandation de mod?");
            russian.Add("FindBugAddModButtonDescription", "Нашли баг? Хотите добавить мод? Пишите сюда!");

            //Componet: failedToParseFile
            english.Add("failedToParseFile", "Failed to parse the file");
            german.Add("failedToParseFile", "Analyse der Datei fehlgeschlagen");
            polish.Add("failedToParseFile", TranslationNeeded);
            french.Add("failedToParseFile", "Échec de l'analyse du fichier");
            russian.Add("failedToParseFile", "Ошибка обработки файла");

            //Componet: rebootTryAgain
            english.Add("rebootTryAgain", "Please reboot the application and try again");
            german.Add("rebootTryAgain", "Bitte starte die Anwendung neu und versuch es noch einmal");
            polish.Add("rebootTryAgain", TranslationNeeded);
            french.Add("rebootTryAgain", "Veuillez redémarrer l`application et réessayer");
            russian.Add("rebootTryAgain", "Пожалуйста, перезапустите приложение и попробуйте ещё раз");
            #endregion

            #region Messages from ModSelectionList
            //Componet: testModeDatabaseNotFound
            //
            english.Add("testModeDatabaseNotFound", "CRITICAL: TestMode Database not found at:\n{0}");
            german.Add("testModeDatabaseNotFound", "KRITISCH: Die Datanbank für den Testmodus wurde nicht gefunden:\n{0}");
            polish.Add("testModeDatabaseNotFound", "BŁĄD KRYTYCZNY: Baza danych Trybu Testowego nie znaleziona w lokalizacji:\n{0}");
            french.Add("testModeDatabaseNotFound", "CRITIQUE: Impossible de trouver la base de données du mode de test situé a: \n{0}");
            russian.Add("testModeDatabaseNotFound", "КРИТИЧЕСКАЯ ОШИБКА: Тестовая БД не найдена по адресу:\n{0}");

            //Componet: 
            //
            english.Add("duplicateMods", "CRITICAL: Duplicate mod name detected");
            german.Add("duplicateMods", "KRITISCH: Duplizierter Modname wurde erkannt");
            polish.Add("duplicateMods", "BŁĄD KRYTYCZNY: Wykryto zduplikowaną nazwę modyfikacji");
            french.Add("duplicateMods", "CRITIQUE: Détection de mods en double");
            russian.Add("duplicateMods", "КРИТИЧЕСКАЯ ОШИБКА: Найден дубикат мода (одинаковое название)");

            //Componet: 
            //
            english.Add("databaseReadFailed", "CRITICAL: Failed to read database\n\nsee Logfile for detailed info");
            german.Add("databaseReadFailed", "KRITISCH: Datenbank konnte nicht gelesen werden\n\nin der Protokolldatei stehen weitere Informationen zu diesem Fehler");
            polish.Add("databaseReadFailed", "BŁĄD KRYTYCZNY: Nie udało się wczytać bazy danych");
            french.Add("databaseReadFailed", "CRITIQUE: Impossible de lire la base de données");
            russian.Add("databaseReadFailed", "КРИТИЧЕСКАЯ ОШИБКА: Ошибка чтения базы данных!\nПодробности в log-файле");

            //Componet: 
            //
            english.Add("configSaveSuccess", "Config Saved Successfully");
            german.Add("configSaveSuccess", "Konfiguration wurde erfolgreich gespeichert");
            polish.Add("configSaveSuccess", "Udało się zapisać konfigurację");
            french.Add("configSaveSuccess", "Succès sauvegarde de la configuration");
            russian.Add("configSaveSuccess", "Конфигурация успешно сохранена");

            //Componet: 
            //
            english.Add("selectConfigFile", "Select a user preference file to load");
            german.Add("selectConfigFile", "Wählen Sie die benutzerdefinierte Datei aus, die geladen werden soll");
            polish.Add("selectConfigFile", "Wybierz plik preferencji do wczytania");
            french.Add("selectConfigFile", "Sélectionnez un fichier de préférences utilisateur à charger");
            russian.Add("selectConfigFile", "Выберите файл для загрузки пользовательских настроек");

            //Componet: 
            //
            english.Add("configLoadFailed", "The preference file could not be loaded, loading in standard mode");
            german.Add("configLoadFailed", "Die Konfigurationsdatei konnte nicht geladen werden, lade im Standard Modus");
            polish.Add("configLoadFailed", "Nie można wczytać pliku knfiguracji, ładowanie trybu podstawowego");
            french.Add("configLoadFailed", "Impossible de charge le fichier de préférences. Chargement en mode normal");
            russian.Add("configLoadFailed", "Файл конфигурации не может быть загружен, запуск в обычном режиме");

            //Componet: 
            //
            english.Add("modNotFound", "The mod, \"{0}\" was not found in the modpack. It could have been renamed or removed.");
            german.Add("modNotFound", "Der Mod, \"{0}\" wurde im Modpack nicht gefunden. Er könnte umbenannt oder entfernt worden sein.");
            polish.Add("modNotFound", "Modyfikacja \"{0}\" nie została znaleziona w paczce. Sprawdź, czy nie została usunięta lub zmieniona nazwa.");
            french.Add("modNotFound", "Impossible de trouver le mod, \"{0}\" dans le mod pack. Il est possible qu`il sois supprimé ou changé de nom");
            russian.Add("modNotFound", "Мод \"{0}\" не найден в модпаке. Он мог быть переименован или удалён.");

            //Componet: 
            //
            english.Add("configNotFound", "The config \"{0}\" was not found for mod \"{1}\". It could have been renamed or removed.");
            german.Add("configNotFound", "Die Config \"{0}\" wurde nicht für den Mod gefunden \"{1}\". Er könnte umbenannt oder entfernt worden sein.");
            polish.Add("configNotFound", "Konfiguracja \"{0}\" nie została znaleziona dla modyfikacji \"{1}\". Sprawdź, czy nie została usunięta lub zmieniona nazwa.");
            french.Add("configNotFound", "Impossible de trouver la configuration \"{0}\" pour le mod \"{1}\". Il est possible qu`il sois supprimé ou changé de nom");
            russian.Add("configNotFound", "Не удалось найти конфигурацию \"{0}\" для мода \"{1}\". Она могла быть переименована или удалена.");

            //Componet: 
            //
            english.Add("modDeactivated", "The mod \"{0}\" is currently deactivated in the modpack and could not to be selected to install.");
            german.Add("modDeactivated", "Der Mod \"{0}\" ist derzeit im Modpack deaktiviert und steht für die Installation nicht zur Verfügung.");
            polish.Add("modDeactivated", "Modyfikacja \"{0}\" jest obecnie zdezaktywowana w paczce i nie może zostać wybrana.");
            french.Add("modDeactivated", "Le mod est actuellement désactivé dans le mod pack et ne seras pas installé");
            russian.Add("modDeactivated", "Мод \"{0}\" в данный момент отключён в модпаке и не может быть выбран для установки.");

            //Componet: 
            //
            english.Add("configDeactivated", "The config \"{0}\" of \"{1}\" is currently deactivated in the modpack and could not to be selected to install.");
            german.Add("configDeactivated", "Die Konfiguration \"{0}\" von \"{1}\" ist derzeit im Modpack deaktiviert und steht für die Installation nicht zur Verfügung.");
            polish.Add("configDeactivated", "Konfiguracja \"{0}\" z \"{1}\" jest obecnie zdezaktywowana w paczce i nie może zostać wybrana.");
            french.Add("configDeactivated", "La configuration \"{0}\" du mod \"{1}\" est actuellement désactivé dans le mod pack et ne seras pas installé");
            russian.Add("configDeactivated", "Конфигурация \"{0}\" для \"{1}\" в данный момент отключена в модпаке и не может быть выбрана для установки.");

            //Componet: 
            //
            english.Add("modsNotFoundTechnical", "The following mods could not be found and were most likely removed. There are only technical names available:\n{0}");
            german.Add("modsNotFoundTechnical", "Die folgenden Modifikationen können nicht gefunden werden und wurden wahrscheinlich entfernt/gelöscht. Es sind leider nur technische Namen verfügbar:\n{0}");
            polish.Add("modsNotFoundTechnical", "Następujące modyfikacje nie zostały znalezione, najprawdopodobniej zostały usunięte:\n{0}");
            french.Add("modsNotFoundTechnical", "Les mods suivants n'ont pas pu être trouvés et ont probablement été supprimés. Il n'y a que des noms techniques disponibles:\n{0}");
            russian.Add("modsNotFoundTechnical", "Данные моды не найдены, вероятно они были удалены. Есть только их техническое название:\n{0}");

            //Componet: 
            //
            english.Add("modsBrokenStructure", "The following mods were disabled due to modifications in the package structure. You need to re-check them if you want to install them:\n");
            german.Add("modsBrokenStructure", "Die folgenden Mods wurden aufgrund von Änderungen in der Paketstruktur deaktiviert. Sie müssen sie erneut auswählen, wenn Sie sie installieren möchten:\n");
            polish.Add("modsBrokenStructure", "Następujące modyfikacje zostały wyłączone ze względu na zmiany w strukturze paczki. Zaznacz je ponownie, jeśli chcesz je zainstalować:\n");
            french.Add("modsBrokenStructure", "Les mods suivants ont été désactivés en raison de modifications dans la structure du paquet: vous devez les vérifier de nouveau si vous voulez les installer:\n");
            russian.Add("modsBrokenStructure", "Данные моды были отключены в связи с изменением структуры пакета. Вы можете перепроверить их в случае, если хотите установить их:\n");

            //Componet: 
            //
            english.Add("oldSavedConfigFile", "The saved preferences file your are using is in an outdated format and will be inaccurate in the future. Convert it to the new format?" +
                " (A backup of the old format will be made)");
            german.Add("oldSavedConfigFile", "Die Konfigurationsdatei die benutzt wurde, wird in Zukunft immer ungenauer werden. Soll auf das neue Standardformat umgestellt werden?" +
                " (Eine Sicherung des alten Formats erfolgt)");
            polish.Add("oldSavedConfigFile", "Zapisana konfiguracja jest w przestarzałym formacie i może powodować nieścisłości. Czy chcesz przekonwertować ją na nowszy zapis?");
            french.Add("oldSavedConfigFile", "Le fichier de préférences que vous avez choisis est un format obsolète et seras inexact dans le future. Convertire au nouveau format?");
            russian.Add("oldSavedConfigFile", "Сохранённый файл конфигурации использует устаревший формат и может некорректно работать в будущем. Хотите преобразовать его в новый? Бэкап старого будет так же сохранён.");

            //Componet: 
            //
            english.Add("prefrencesSet", "Preferences Set");
            german.Add("prefrencesSet", "Bevorzugte Einstellungen");
            polish.Add("prefrencesSet", "Preferowane Ustawienia");
            french.Add("prefrencesSet", "Préférences Enregistrées");
            russian.Add("prefrencesSet", "Настройки применены");

            //Componet: 
            //
            english.Add("selectionsCleared", "Selections Cleared");
            german.Add("selectionsCleared", "Auswahl gelöscht");
            polish.Add("selectionsCleared", "Usunięto Zaznaczenia");
            french.Add("selectionsCleared", "Sélections effacées");
            russian.Add("selectionsCleared", "Список выбранных модов очищен");

            //Componet: Expand current tab option
            //
            english.Add("expandAllButton", "Expand Current Tab");
            german.Add("expandAllButton", "Erweitere alle Einträge der aktuellen Registerkarte");
            polish.Add("expandAllButton", "Rozwiń bieżącą kartę");
            french.Add("expandAllButton", "Elargir l'onglet");
            russian.Add("expandAllButton", "Раскрыть текущую вкладку");

            //Componet: Colapse current tab option
            //
            english.Add("colapseAllButton", "Collapse Current Tab");
            german.Add("colapseAllButton", "Reduziere alle Einträge der aktuellen Registerkarte");
            polish.Add("colapseAllButton", "Zwiń bieżącą kartę");
            french.Add("colapseAllButton", "Réduire l'onglet");
            russian.Add("colapseAllButton", "Свернуть текущую вкладку");

            //Componet:
            //
            english.Add("InstallingTo", "Installing to {0}");
            german.Add("InstallingTo", "Installiere nach {0}");
            polish.Add("InstallingTo", "Instalowanie w {0}");
            french.Add("InstallingTo", "Installation à {0}");
            russian.Add("InstallingTo", "Установка в {0}");

            //Section saveConfig
            //
            english.Add("selectWhereToSave", "Select where to save user prefs");
            german.Add("selectWhereToSave", "Bitte wähle wo die Konfiguation gespeichert werden soll");
            polish.Add("selectWhereToSave", "Wybór lokalizacji zapisu preferencji użytkownika");
            french.Add("selectWhereToSave", "Sélectionnez la location pour enregistrer les préférences utilisateur");
            russian.Add("selectWhereToSave", "Выберите путь для сохранения пользовательских настроек");

            //Section addModTreeview
            //
            english.Add("updated", "updated");
            german.Add("updated", "aktualisiert");
            polish.Add("updated", "zaktualizowane");
            french.Add("updated", "Mis à jours");
            russian.Add("updated", "обновлено");
            #endregion

            #region OldFilesToDelete
            //Window header
            english.Add("foundOldFilesHeader", "Old Files Question");
            german.Add("foundOldFilesHeader", "alte Dateien löschen");
            polish.Add("foundOldFilesHeader", "Zapytanie o starsze wersje plików");
            french.Add("foundOldFilesHeader", "Question pour les fichiers anciens (français seulement)");
            russian.Add("foundOldFilesHeader", "Найдены старые файлы");

            //Componet: Found zip files to delete 1
            //
            english.Add("foundOldFilesDelete1", "The installer has found the following files that are old and can be deleted");
            german.Add("foundOldFilesDelete1", "Wir haben folgende veralteten Dateien gefunden die gelöscht werden können");
            polish.Add("foundOldFilesDelete1", "Instalator znalazł następujące stare pliki, które mogą zostać usunięte");
            french.Add("foundOldFilesDelete1", "L'installateur a trouvé les vieux fichiers suivants qui peuvent être supprimé");
            russian.Add("foundOldFilesDelete1", "Установщик нашёл старые файлы, которые можно без последствий удалить");

            //Componet: Found zip files to delete 2
            //
            english.Add("foundOldFilesDelete2", "Would you like to delete them?");
            german.Add("foundOldFilesDelete2", "Möchtest du das sie gelöscht werden?");
            polish.Add("foundOldFilesDelete2", "Czy chcesz je usunąć?");
            french.Add("foundOldFilesDelete2", "Voulez vous les supprimer");
            russian.Add("foundOldFilesDelete2", "Хотите удалить их?");
            #endregion

            #region SelectionViewer
            //Component: SelectConfigLabel
            //The label in the window informing the user to select a config option to use
            english.Add("SelectConfigLabel", "Select a config to load");
            german.Add("SelectConfigLabel", "Wähle eine Konfiguation zum Laden aus");
            polish.Add("SelectConfigLabel", "Wybierz konfigurację do załadowania");
            french.Add("SelectConfigLabel", "Sélectionnez une configuration à charger");
            russian.Add("SelectConfigLabel", "Выберите конфигурацию для загрузки");

            //Component: localFile
            //The text in the first radioButton in the selection viewer, for the user to select their own personal config file to load
            english.Add("localFile", "Local File");
            german.Add("localFile", "Lokale Datei");
            polish.Add("localFile", "Plik lokalny");
            french.Add("localFile", "Fichier local");
            russian.Add("localFile", "Локальный файл");

            //Component: radioButtonToolTip
            //
            english.Add("createdAt", "Created at: {0}");
            german.Add("createdAt", "Erstellt am: {0}");
            polish.Add("createdAt", "Utworzono w: {0}");
            french.Add("createdAt", "Créé à: {0}");
            #endregion

            #region Installer Messages
            //Componet: extractingPackage
            //
            english.Add("extractingPackage", "Extracting package");
            german.Add("extractingPackage", "Entpacke Paket");
            polish.Add("extractingPackage", "Wypakowywanie paczki");
            french.Add("extractingPackage", "Extraction du package");
            russian.Add("extractingPackage", "Распаковывается пакет");

            //Componet: parallelExtraction
            //
            english.Add("parallelExtraction", "Completed parallel extraction threads:");
            german.Add("parallelExtraction", "Parallele Entpack-Prozeduren beendet:");
            polish.Add("parallelExtraction", "Zakończono jednoczesne wypakowywanie:");// IMHO Thread is a word that IT guys understand in this case, so i skipped it. The meaning is still the same.
            french.Add("parallelExtraction", "Threads d'extraction parallèles terminés:");
            russian.Add("parallelExtraction", "Количество завершённых потоков установки:");

            //Componet: file
            //
            english.Add("file", "File");
            german.Add("file", "Datei");
            polish.Add("file", "Plik");
            french.Add("file", "Fichier");
            russian.Add("file", "Файл");

            //Componet: size
            //
            english.Add("size", "Size");
            german.Add("size", "Größe");
            polish.Add("size", "Rozmiar");
            french.Add("size", "Taille");
            russian.Add("size", "Размер");

            //Componet: backupModFile
            //
            english.Add("backupModFile", "Backing up mod file");
            german.Add("backupModFile", "Mod Dateien sichern");
            polish.Add("backupModFile", "Stwórz kopię zapasową pliku modyfikacji");
            french.Add("backupModFile", "Sauvegarde du fichier mod");
            russian.Add("backupModFile", "Создаётся бэкап мода");

            //Componet: backupUserDatas
            //
            english.Add("backupUserDatas", "Backing up user data");
            german.Add("backupUserDatas", "Benutzerdaten sichern");
            polish.Add("backupUserDatas", "Stwórz kopię zapasową danych użytkownika");
            french.Add("backupUserDatas", "Sauvegarde des données utilisateur");
            russian.Add("backupUserDatas", "Создаётся бэкап пользовательских данных");

            //Componet: backupSystemDatas
            //
            english.Add("backupSystemDatas",  "Backing up mod related data");
            german.Add("backupSystemDatas", TranslationNeeded);
            polish.Add("backupSystemDatas", TranslationNeeded);
            french.Add("backupSystemDatas", TranslationNeeded);
            russian.Add("backupSystemDatas", "Создаётся бэкап данных мода");

            //Componet: deletingFiles
            //
            english.Add("deletingFiles", "Deleting files");
            german.Add("deletingFiles", "Lösche Dateien");
            polish.Add("deletingFiles", "Usuwanie plików");
            french.Add("deletingFiles", "Suppression de fichiers");
            russian.Add("deletingFiles", "Удаляются файлы");

            //Component DeleteMods
            //
            english.Add("scanningModsFolders", "Scanning mods folders ...");
            german.Add("scanningModsFolders", "Durchsuche Mod Verzeichnisse ...");
            polish.Add("scanningModsFolders", TranslationNeeded);
            french.Add("scanningModsFolders", TranslationNeeded);
            russian.Add("scanningModsFolders", "Сканируются папки модов...");


            //Componet: deletingWOTCache
            //
            english.Add("deletingWOTCache", "Deleting WoT cache");
            german.Add("deletingWOTCache", "WoT Zwischenspeicher löschen");
            polish.Add("deletingWOTCache", "Usuwanie cache WoTa");
            french.Add("deletingWOTCache", "Suppression du cache WoT");
            russian.Add("deletingWOTCache", "Удаляется кэш WoT");

            //Componet: restoringUserData
            //
            english.Add("restoringUserData", "Restoring user data");
            german.Add("restoringUserData", "Benutzerdaten wiederherstellen");
            polish.Add("restoringUserData", "Przywracanie danych użytkownika");
            french.Add("restoringUserData", "Restoration des données utilisateur");
            russian.Add("restoringUserData", "Восстанавливаются пользовательские данные");

            //Componet: restoringSystemData
            //
            english.Add("restoringSystemData", "Restoring Mod-files");
            german.Add("restoringSystemData", "Mod-Dateien wiederherstellen");
            polish.Add("restoringSystemData", TranslationNeeded);
            french.Add("restoringSystemData", TranslationNeeded);
            russian.Add("restoringSystemData", "Восстанавливаются файлы модификаций");


            //Component restoringData before (function moveFileEx)
            //
            english.Add("writingInstallationLogfile", "writing {0} files to installation-logfile ...");
            german.Add("writingInstallationLogfile", "schreibe {0} Dateieinträge in die Installations-Logdatei ...");
            polish.Add("writingInstallationLogfile", TranslationNeeded);
            french.Add("writingInstallationLogfile", TranslationNeeded);
            russian.Add("writingInstallationLogfile", "записываются {0} файлов в log-файл установки...");

            //Componet: unpackingXMLFiles
            //
            english.Add("unpackingXMLFiles", "Unpacking local XML file");
            german.Add("unpackingXMLFiles", "Entpacke lokale XML Dateien");
            polish.Add("unpackingXMLFiles", "Rozpakowywanie lokalnego pliku XML");
            french.Add("unpackingXMLFiles", "Décompresser le fichier XML local");
            russian.Add("unpackingXMLFiles", "Распаковываются локальные XML-файлы");

            //Componet: patchingFile
            //
            english.Add("patchingFile", "Patching file");
            german.Add("patchingFile", "Datei wird geändert");
            polish.Add("patchingFile", "Aktualizowanie plików");
            french.Add("patchingFile", "Patch du fichier");
            russian.Add("patchingFile", "Идёт патч файла");

            //Componet: extractingUserMod
            //
            english.Add("extractingUserMod", "Extracting user mod");
            german.Add("extractingUserMod", "Benutzer Modifikationen entpacken");
            polish.Add("extractingUserMod", "Wypakowywanie modyfikacji");
            french.Add("extractingUserMod", "Extraction des mods utilisateur");

            //Componet: userPatchingFile
            //
            english.Add("userPatchingFile", "User patching file");
            german.Add("userPatchingFile", "Benutzer Datei wird geändert");
            polish.Add("userPatchingFile", "Aktualizowanie plików użytkownika");
            french.Add("userPatchingFile", "Fichier utilisateur patch");
            russian.Add("userPatchingFile", "Идёт патч пользовательского файла");

            //Component: ExtractAtlases
            english.Add("AtlasExtraction", "Extracting Atlas file");
            german.Add("AtlasExtraction", "Entpacke Atlas Datei");
            polish.Add("AtlasExtraction", "Wypakuj plik Atlas");
            french.Add("AtlasExtraction", "Extraction des fichiers Atlas");
            russian.Add("AtlasExtraction", "Распаковывается файл-атлас");

            //Component: ExtractAtlases
            english.Add("AtlasTexture", "Texture");
            german.Add("AtlasTexture", "Textur");
            polish.Add("AtlasTexture", "Tekstury");
            french.Add("AtlasTexture", "Texture");
            russian.Add("AtlasTexture", "Текстура");

            //Component: CreatingAtlases
            english.Add("AtlasCreating", "Creating Atlas file");
            german.Add("AtlasCreating", "Erstelle Atlas Datei");
            polish.Add("AtlasCreating", "Tworzenie pliku Atlas");
            french.Add("AtlasCreating", "Creations des fichiers Atlas");
            russian.Add("AtlasCreating", "Создаётся файл-атлас");

            //Component: CreatingAtlases
            english.Add("AtlasOptimations", "Optimizations");
            german.Add("AtlasOptimations", "Optimierungen");
            polish.Add("AtlasOptimations", "Optymalizacje");
            french.Add("AtlasOptimations", "Optimisation");

            //Componet: installingUserFonts
            //
            english.Add("installingUserFonts", "Installing user fonts");
            german.Add("installingUserFonts", "Benutzer Schriftsätze installieren");
            polish.Add("installingUserFonts", "Instalowanie czcionek użytkownika");
            french.Add("installingUserFonts", "Installation des polices utilisateur");
            russian.Add("installingUserFonts", "Устанавливаются пользовательские шрифты");

            //Componet: CheckDatabase
            //
            english.Add("checkDatabase", "Checking the database for outdated or no longer needed files");
            german.Add("checkDatabase", "Durchsuche das Dateiarchive nach veralteten oder nicht mehr benötigten Dateien");
            polish.Add("checkDatabase", "Trwa przeszukiwanie w bazie danych przedawnionych i niepotrzebnych plików");
            french.Add("checkDatabase", "Vérification de la base de données pour les fichiers périmés ou non nécessaires");
            russian.Add("checkDatabase", "Идёт проверка БД на наличие неактуальных или ненужных файлов");

            //Component: 
            //function checkForOldZipFiles() 
            english.Add("parseDownloadFolderFailed", "Parsing the \"{0}\" folder failed.");
            german.Add("parseDownloadFolderFailed", "Durchsehen des \"{0}\" Verzeichnisses ist fehlgeschlagen.");
            polish.Add("parseDownloadFolderFailed", "Pobieranie informacji o folderze \"{0}\" zakończone niepowodzeniem");
            french.Add("parseDownloadFolderFailed", "L'analyse du dossier \"{0}\" a échoué.");
            russian.Add("parseDownloadFolderFailed", "Не удалось обработать папку \"{0}\"");

            //Componet: installation finished
            //
            english.Add("installationFinished", "Installation is finished");
            german.Add("installationFinished", "Die Installation ist abgeschlossen");
            polish.Add("installationFinished", "Instalacja jest zakończona");
            french.Add("installationFinished", "L'installation est terminée");
            russian.Add("installationFinished", "Установка завершена");

            //Componet:
            //
            english.Add("WoTRunningHeader", "WoT is Running");
            german.Add("WoTRunningHeader", "WoT wird gerade ausgeführt.");
            polish.Add("WoTRunningHeader", "WoT jest uruchomiony");
            french.Add("WoTRunningHeader", "WoT est en cours d`éxecution");
            russian.Add("WoTRunningHeader", "World of Tanks запущен");

            //Componet:
            //
            english.Add("WoTRunningMessage", "Please close World of Tanks to continue");
            german.Add("WoTRunningMessage", "Um Fortzufahren, schliesse bitte World of Tanks.");
            polish.Add("WoTRunningMessage", "Proszę zamknąć World of Tanks, aby kontynuować");
            french.Add("WoTRunningMessage", "Veuillez fermer World of Tanks pour continuer");
            russian.Add("WoTRunningMessage", "Закройтие игру, чтобы продолжить");

            //Componet:
            //
            english.Add("KillRunningWoTHeader", "Problem ??");
            german.Add("KillRunningWoTHeader", TranslationNeeded);
            polish.Add("KillRunningWoTHeader", TranslationNeeded);
            french.Add("KillRunningWoTHeader", TranslationNeeded);
            russian.Add("KillRunningWoTHeader", "Проблема?");

            //Componet:
            //
            english.Add("KillRunningWoTMessage", "You were trying to go on now {0}x times, but the game is still not closed.\n\nIn some conditions, the game was closed by user, but is still running in the background (visible via the TaskManager)\n\nShould we try to kill the task for you?");
            german.Add("KillRunningWoTMessage", TranslationNeeded);
            polish.Add("KillRunningWoTMessage", TranslationNeeded);
            french.Add("KillRunningWoTMessage", TranslationNeeded);
            russian.Add("KillRunningWoTMessage", "Вы пытались продолжить работу {0} раз, но игра по-прежнему не закрыта.\n\nВ некоторых случаях, игра могла быть закрытой пользователем, но висеть фоновым процессом, видимым через диспетчер задач.\n\nХотите, чтобы мы попробовали принудительно заверщить процесс?");

            //Componet:
            //
            english.Add("zipReadingErrorHeader", "Incomplete Download");
            german.Add("zipReadingErrorHeader", "Unvollständiger Download");
            polish.Add("zipReadingErrorHeader", "Ściąganie niekompletne");
            french.Add("zipReadingErrorHeader", "Téléchargement incomplet");
            russian.Add("zipReadingErrorHeader", "Незаконченная загрузка");

            //Componet:
            //
            english.Add("zipReadingErrorMessage1", "The zip file");
            german.Add("zipReadingErrorMessage1", "Die Zip-Datei");
            polish.Add("zipReadingErrorMessage1", "Plik skomresowany formatu ZIP ");
            french.Add("zipReadingErrorMessage1", "Le fichier ZIP");
            russian.Add("zipReadingErrorMessage1", "ZIP-архив");

            //Componet:
            //
            english.Add("zipReadingErrorMessage2", "could not be read, most likely due to an incomplete download. Please try again.");
            german.Add("zipReadingErrorMessage2", "Konnte nicht gelesen werden, da es höchstwahrscheinlich ein unvollständiger Download ist. Bitte versuche es später nochmal.");
            polish.Add("zipReadingErrorMessage2", "Nie można odczytać, prawdopodobnie niekompletność pobranych plików. Proszę spróbować ponownie");
            french.Add("zipReadingErrorMessage2", "n'as pas pus être lus, probablement un téléchargement incomplet. Veuillez réeissayer.");
            russian.Add("zipReadingErrorMessage2", "не может быть прочитан, возможно, причиной послужила незаконченная загрузка. Попробуйте ещё раз.");

            //Componet:
            //
            english.Add("zipReadingErrorMessage3", "Could not be read.");
            german.Add("zipReadingErrorMessage3", "Konnte nicht gelesen werden.");
            polish.Add("zipReadingErrorMessage3", "Nie można odczytać.");
            french.Add("zipReadingErrorMessage3", "n'as pas pus être lus");
            russian.Add("zipReadingErrorMessage3", "Сбой чтения.");

            //Componet: 
            //
            english.Add("patchingSystemDeneidAccessMessage", "The patching system was denied access to the patch folder. Retry as Administrator. If you see this again, you need to fix your" +
                " file and folder security permissions");
            german.Add("patchingSystemDeneidAccessMessage", "Dem Patching-System wurde der Zugriff auf den Patch-Ordner verweigert. Wiederholen als Administrator. Wenn Sie dies wieder sehen," +
                " müssen Sie Ihre Datei- und Ordnersicherheitsberechtigungen reparieren");
            polish.Add("patchingSystemDeneidAccessMessage", "Nie uzyskano dostępu do folderu patcha. Spróbuj ponownie jako administrator. Jeśli widzisz to ponownie, to zmień ustawienia" +
                " pozwoleń dostępu do folderów.");
            french.Add("patchingSystemDeneidAccessMessage", "Le système de patching s'est vu refuser l'accès au dossier de patch. Réessayez en tant qu'administrateur. Si vous voyez ceci" +
                " à nouveau, assurez vous que vos permissions de sécurités de dossiers et de fichiers son suffisantes.");
            russian.Add("patchingSystemDeneidAccessMessage", "Системе патчинга был отказан доступ к папке с патчами. Попробуйте повторить операцию от имени администратора. " +
                "Если вы снова видите это окно, то исправьте ошибки в правах доступа к файлам и папкам.");

            //Componet: 
            //
            english.Add("patchingSystemDeneidAccessHeader", "Access Denied");
            german.Add("patchingSystemDeneidAccessHeader", "Zugriff abgelehnt");
            polish.Add("patchingSystemDeneidAccessHeader", "Odmowa dostępu");
            french.Add("patchingSystemDeneidAccessHeader", "Accès refusé");
            russian.Add("patchingSystemDeneidAccessHeader", "В доступе отказано");

            //Componet: Failed To Delete folder
            //
            english.Add("folderDeleteFailed", "Failed to delete the folder");
            german.Add("folderDeleteFailed", "Löschen des Verzeichnis fehlgeschlagen");
            polish.Add("folderDeleteFailed", "Próba usunięcia folderu zakończona niepowodzeniem");
            french.Add("folderDeleteFailed", "Échec de la suppression du dossier");
            russian.Add("folderDeleteFailed", "Не удалось удалить папку");

            //Componet: Failed To Delete file
            //
            english.Add("fileDeleteFailed", "Failed to delete the file");
            german.Add("fileDeleteFailed", "Löschen der Datei fehlgeschlagen");
            polish.Add("fileDeleteFailed", "Próba usunięcia pliku zakończona niepowodzeniem");
            french.Add("fileDeleteFailed", "Échec de la supression du fichier");
            russian.Add("fileDeleteFailed", "Не удалось удалить файл");

            //Component: DeleteBackupFolder
            //
            english.Add("DeleteBackupFolder", "Backups");
            german.Add("DeleteBackupFolder", "Sicherungen");
            polish.Add("DeleteBackupFolder", TranslationNeeded);
            french.Add("DeleteBackupFolder", TranslationNeeded);
            russian.Add("DeleteBackupFolder", "Бэкапы");
            #endregion

            #region Install finished window
            //Componet: InstallCompleteLabel
            //
            english.Add("InstallCompleteLabel", "The Installation is complete. Would you like to...");
            german.Add("InstallCompleteLabel", "Installation ist beendet. Willst du...");
            polish.Add("InstallCompleteLabel", "Instalacja jest zakończona. Czy chciałbyś...");
            french.Add("InstallCompleteLabel", "L'installation est terminée. Voudriez-vous...");
            russian.Add("InstallCompleteLabel", "Установка завершена. Хотите...}");

            //Componet: StartTanksButton
            //
            english.Add("StartTanksButton", "Start the game? (WorldofTanks.exe)");
            german.Add("StartTanksButton", "Das Spiel starten? (WorldofTanks.exe)");
            polish.Add("StartTanksButton", "Uruchomić grę? (WorldofTanks.exe)");
            french.Add("StartTanksButton", "Démarrez le jeu? (WorldofTanks.exe)");
            russian.Add("StartTanksButton", "Запустить игру? (WorldofTanks.exe)");

            //Componet: StartWoTLauncherButton
            //
            english.Add("StartWoTLauncherButton", "Start the game launcher? (WoTLauncher.exe)");
            german.Add("StartWoTLauncherButton", "Den Spiel Launcher starten? (WoTLauncher.exe)");
            polish.Add("StartWoTLauncherButton", "Uruchomić launcher? (WoTLauncher.exe)");
            french.Add("StartWoTLauncherButton", "Démarrez le lanceur de jeux? (WoTLauncher.exe)");
            russian.Add("StartWoTLauncherButton", "Запустить лончер? (WoTLauncher.exe)");

            //Componet: StartXVMStatButton
            //
            english.Add("StartXVMStatButton", "Open your web browser to the xvm statistics login website?");
            german.Add("StartXVMStatButton", "Öffne Deinen Browser auf der XVM Statistik Login Webseite?");
            polish.Add("StartXVMStatButton", "Otworzyć stronę statystyk XVM ?");
            french.Add("StartXVMStatButton", "Ouvrir votre navigateur Web vers le site de connexion aux statistiques xvm?");
            russian.Add("StartXVMStatButton", "Открыть браузер на сайте XVM для активации статистики?");

            //Componet: CloseApplicationButton
            //
            english.Add("CloseApplicationButton", "Close the application?");
            german.Add("CloseApplicationButton", "Anwendung schließen");
            polish.Add("CloseApplicationButton", "Zamknij aplikację");
            french.Add("CloseApplicationButton", "Fermer l'application");
            russian.Add("CloseApplicationButton", "Закрыть приложение?");

            //Componet: StartXVMStatButton_Click
            //localization to which page you will jump
            english.Add("xvmUrlLocalisation", "en");
            german.Add("xvmUrlLocalisation", "de");
            polish.Add("xvmUrlLocalisation", "en");
            french.Add("xvmUrlLocalisation", "fr");
            russian.Add("xvmUrlLocalisation", "ru");

            //Componet: loadingGifpreview
            //GifPreview.cs
            english.Add("loadingGifpreview", "Loading Picture Preview");
            german.Add("loadingGifpreview", "Ladebild Vorschau");
            polish.Add("loadingGifpreview", "Ładowanie Podglądu");
            french.Add("loadingGifpreview", "Chargement de l'image de prévisualisation");
            russian.Add("loadingGifpreview", "Загрузка изображения для предпросмотра");
            #endregion

            #region Diagnostics
            //Component: MainTextBox
            //
            english.Add("MainTextBox", "You can use the options below to try to diagnose or solve the issues you are having.");
            german.Add("MainTextBox", "Du kannst mit den untenstehenden Optionen Probleme mit dem Spiel zu diagnostizieren und ggf. zu beheben.");
            polish.Add("MainTextBox", "Opcje diagnostyczne i rozwiązywanie problemów");
            french.Add("MainTextBox", "Vous pouvez utiliser les options ci dessous pour essayer de diagnostiqué ou résoudre les soucis que vous avez");
            russian.Add("MainTextBox", "Вы можете попробовать способы ниже для диагностики или выявления проблем с клиентом игры.");

            //Component: LaunchWoTLauncher
            //
            english.Add("LaunchWoTLauncher", "Start the World of Tanks launcher in integrity validation mode");
            german.Add("LaunchWoTLauncher", "Starte den \"World of Tanks Launcher\" im Integritätsvalidierungsmodus");
            polish.Add("LaunchWoTLauncher", "Uruchom launcher World of Tanks w trybie sprawdzania integralności.");
            french.Add("LaunchWoTLauncher", "Lancé le launcher world of tanks en mode vérification d'intégrité");
            russian.Add("LaunchWoTLauncher", "Запустить лаунчер World of Tanks в режиме проверки целостности");

            //Component: CollectLogInfo
            //
            english.Add("CollectLogInfo", "Collect all log files into a zip file to report a problem");
            german.Add("CollectLogInfo", "Erstelle eine Zip Datei mit allen Protokolldateien um ein Problem zu melden.");
            polish.Add("CollectLogInfo", "Zbierz pliki logów w plik zip, by zgłosić problem");
            french.Add("CollectLogInfo", "Collecté tous les fichiers log dans un fichier zip pour reporter un problème");
            russian.Add("CollectLogInfo", "Собрать все log-файлы в ZIP-архив для отчёта об ошибке");

            //Component: SelectedInstallation
            //
            english.Add("SelectedInstallation", "Currently Selected Installation: ");
            german.Add("SelectedInstallation", "Aktuell gewählte Installation");
            polish.Add("SelectedInstallation", "Obecnie Wybrana Instalacja: ");
            french.Add("SelectedInstallation", "Installation actuellement sélectionner: ");
            russian.Add("SelectedInstallation", "Текущая папка с игрой: ");

            //Component: collectionLogInfo
            //
            english.Add("collectionLogInfo", "Collecting log files...");
            german.Add("collectionLogInfo", "Sammeln der Protokolldateien...");
            polish.Add("collectionLogInfo", "Zbieranie logów...");
            french.Add("collectionLogInfo", "Collection des fichiers log...");
            russian.Add("collectionLogInfo", "Идёт сбор log-файлов...");

            //Component: startingLauncherRepairMode
            //
            english.Add("startingLauncherRepairMode", "Starting WoTLauncher in integrity validation mode...");
            german.Add("startingLauncherRepairMode", "Starte den WoT Launcher im Integritätsvalidierungsmodus...");
            polish.Add("startingLauncherRepairMode", "Uruchamianie WoTLaunchera w trybie sprawdzania integralności...");
            french.Add("startingLauncherRepairMode", "Lancement de WoTLauncher and mode the validation d'intégrité...");
            russian.Add("startingLauncherRepairMode", "Запускаю WoTLauncher в режиме проверки целостности...");

            //Component: failedStartLauncherRepairMode
            //
            english.Add("failedStartLauncherRepairMode", "Failed to start WoT Launcher in Repair mode");
            german.Add("failedStartLauncherRepairMode", "Der WoT Launcher konnte nicht im Reparaturmodus gestartet werden");
            polish.Add("failedStartLauncherRepairMode", "Nie udało się uruchomić launchera WoT w trybie naprawy");
            french.Add("failedStartLauncherRepairMode", "Erreur lors du lancement de WoTLauncher en mode de réparation");
            russian.Add("failedStartLauncherRepairMode", "Не удалось запустить WoTLauncher в режиме проверки целостности");

            //Component: failedCollectFile
            //
            english.Add("failedCollectFile", "Failed to collect the file ");
            german.Add("failedCollectFile", "Fehler beim Sammeln der Datei ");
            polish.Add("failedCollectFile", "Nie udało się zebrać plików ");
            french.Add("failedCollectFile", "Erreur lors de la collecte du fichier");
            russian.Add("failedCollectFile", "Не найден файл ");

            //Component: failedCreateZipfile
            //
            english.Add("failedCreateZipfile", "Failed to create the zip file ");
            german.Add("failedCreateZipfile", "Fehler beim Erstellen der Zip-Datei ");
            polish.Add("failedCreateZipfile", "Nie udało się stworzyć pliku zip ");
            french.Add("failedCreateZipfile", "Erreur lors de la création du fichier zip ");
            russian.Add("failedCreateZipfile", "Не удалось создать ZIP-архив");

            //Component: launcherRepairModeStarted
            //
            english.Add("launcherRepairModeStarted", "Repair mode successfully started");
            german.Add("launcherRepairModeStarted", "Reparaturmodus wurde erfolgreich gestartet");
            polish.Add("launcherRepairModeStarted", "Uruchomiono tryb naprawy");
            french.Add("launcherRepairModeStarted", "Mode de réparation démarrer avec succès");
            russian.Add("launcherRepairModeStarted", "Проверка целостности успешно начата");

            //Component: ChangeInstall
            //
            english.Add("ChangeInstall", "Change selected WoT install");
            german.Add("ChangeInstall", "Ändere aktuelle WoT Installation");
            polish.Add("ChangeInstall", "Zmień zaznaczoną instalację WoT");
            french.Add("ChangeInstall", "Changer le dossier d'installation WoT");
            russian.Add("ChangeInstall", "Изменить папку с игрой");

            //Component: zipSavedTo
            //
            english.Add("zipSavedTo", "Zip file saved to: ");
            german.Add("zipSavedTo", "Zip-Datei gespeichert in: ");
            polish.Add("zipSavedTo", "Plik zip zapisano do: ");
            french.Add("zipSavedTo", "Fichier zip sauvegarder à: ");
            russian.Add("zipSavedTo", "ZIP-архив успешно сохранён в: ");

            //Component: ModSelectionList
            //Component: seachCB ToolTip
            english.Add("searchToolTip", "You can also search for multiple name parts, separated by a * (asterisk).\nFor example: config*willster419 will display as search result: Willster419\'s Config");
            german.Add("searchToolTip", "Du kannst auch nach mehreren Namensteilen suchen, getrennt durch ein * (Sternchen).\nZum Beispiel: config*willster419  wird als Suchergebnis anzeigen: Willster419\'s Config");
            polish.Add("searchToolTip", "Można również wyszukiwać wiele części nazw oddzielonych gwiazdką (*).\nNa przykład: config * willster419 wyświetli się jako wynik wyszukiwania: Willster419's Config");
            french.Add("searchToolTip", "Vous pouvez également rechercher plusieurs parties de nom, séparées par un * (astérisque).\nPar exemple: config *" +
                " willster419 affichera comme résultat de la recherche: Config de Willster419");
            russian.Add("searchToolTip", "Вы так же можете искать по нескольким частям названия, разделяя их * (звёздочкой).\nК примеру, config*willster419 покажет в качестве результата поиска Willster419\'s Config");

            //Component: ModSelectionList
            //Component: seachTB
            english.Add("searchTB", "Search Mod Name:");
            german.Add("searchTB", "Suche Mod Namen:");
            polish.Add("searchTB", "Wyszukaj nazwę modu:");
            french.Add("searchTB", "Rechercher le nom du mod:");
            russian.Add("searchTB", "Найти мод по названию:");
            #endregion

            #region Advanced Settings View
            //Component: form name
            english.Add("AdvancedSettings", "Advanced Settings");
            german.Add("AdvancedSettings", "Erweiterte Einstellungen");
            polish.Add("AdvancedSettings", "Ustawienia Zaawansowane");
            french.Add("AdvancedSettings", "Configurations avancé");
            russian.Add("AdvancedSettings", "Расширенные настройки");

            //Component: AdvancedSettingsHeader
            english.Add("AdvancedSettingsHeader", "Hover over a setting to see its description");
            german.Add("AdvancedSettingsHeader", "Mit der Maus über die Einstellungen fahren um die Beschreibungen einzublenden");
            polish.Add("AdvancedSettingsHeader", "NajedŸ kursorem, aby zobaczyæ opis");
            french.Add("AdvancedSettingsHeader", "Survoler un paramètre pour voire sa description");
            russian.Add("AdvancedSettingsHeader", "Наведите мышью на настройку для показа описания");

            //Component: UseAltUpdateMethodCB
            english.Add("UseAltUpdateMethodCB", "Use alternative update method");
            german.Add("UseAltUpdateMethodCB", "Eine alternative Updatemethode verwenden");
            polish.Add("UseAltUpdateMethodCB", "Użyj alternatywnej metody aktualizacji");
            french.Add("UseAltUpdateMethodCB", "Utiliser la methode alternative de mise à jour");
            russian.Add("UseAltUpdateMethodCB", "Использовать альтернативный метод обновлений");

            //Component: UseAltUpdateMethodCBDescription
            english.Add("UseAltUpdateMethodCBDescription", "Use the alternative update method. Takes longer but should help with anti-virus software");
            german.Add("UseAltUpdateMethodCBDescription", "Die alternative Updatemethode dauert länger, hilft aber bei Problemen (bspw. Fehlalarm) mit Anti-Virus-Programmen");
            polish.Add("UseAltUpdateMethodCBDescription", "U¿yj alternatywnej metody aktualizacji. Wyd³u¿y to potrzebny czas, ale pomo¿e przy problemach z oprogramowaniem antywirusowym");
            french.Add("UseAltUpdateMethodCBDescription", "Utiliser la methode alternative de mise à jour. Plus long mais devrais aider avec les applications anti-virus");
            russian.Add("UseAltUpdateMethodCBDescription", "Использование альтернативного метода обновления. Займёт больше времени, но должно избавить от проблем с антивирусом");

            //Component: UseBetaDatabaseCB
            english.Add("UseBetaDatabaseCB", "Use beta database");
            german.Add("UseBetaDatabaseCB", "Die Beta-Version der Datenbank verwenden");
            polish.Add("UseBetaDatabaseCB", "Użyj wersji beta bazy danych");
            french.Add("UseBetaDatabaseCB", "Utiliser la base de données beta");
            russian.Add("UseBetaDatabaseCB", "Использовать бета-версию БД");

            //Component: UseBetaApplicationCB
            english.Add("UseBetaApplicationCB", "Use beta application");
            german.Add("UseBetaApplicationCB", "Die Beta-Version des ModPack Managers verwenden");
            polish.Add("UseBetaApplicationCB", "Użyj wersji beta bazy aplikacji");
            french.Add("UseBetaApplicationCB", "Utiliser l'application beta");
            russian.Add("UseBetaApplicationCB", "Использовать бета-версию программы");

            //Component: UseBetaDatabaseCBDescription
            english.Add("UseBetaDatabaseCBDescription", "Use the latest beta database. Mod stability is not guaranteed");
            german.Add("UseBetaDatabaseCBDescription", "Verwende die letzte Beta-Version des ModPack Datenbank. Die Stabilität der Mods kann nicht garantiert werden, jedoch werden hier auch Fehlerbehebungen als erstes getestet und implementiert.");
            polish.Add("UseBetaDatabaseCBDescription", "Użyj ostatniej wersji beta bazy danych. Nie gwarantujemy stabilności modyfikacji.");
            french.Add("UseBetaDatabaseCBDescription", "Utiliser la dernière base de données beta. La stabilité des mods n'est pas garantie");
            russian.Add("UseBetaDatabaseCBDescription", "Использовать последнюю доступную бета-версию БД. Стабильность модов не гарантирована.");

            //Component: UseBetaApplicationCBDescription
            english.Add("UseBetaApplicationCBDescription", "Use the latest beta application. Translations and application stability are not guaranteed");
            german.Add("UseBetaApplicationCBDescription", "Verwende die letzte Beta-Version des ModPack Managers. Fehlerfreie Übersetzungen und Programmstabilität können nicht garantiert werden.");
            polish.Add("UseBetaApplicationCBDescription", "Użyj ostatniej wersji beta aplikacji. Nie gwarantujemy stabilności ani tłumaczenia aplikacji.");
            french.Add("UseBetaApplicationCBDescription", "Utiliser la dernière version beta. Les traductions et la stabilité de l'application ne sont pas garanties");
            russian.Add("UseBetaApplicationCBDescription", "Использовать последнюю доступную бета-версию программы. Корректность перевода и стабильность приложения не гарантированы.");

            //Component: notifying the user the change won't take effect until application restart
            english.Add("noChangeUntilRestart", "This option won't take effect until application restart");
            german.Add("noChangeUntilRestart", "Diese Option hat keine Auswirkungen bis das Programm neu gestartet wurde");
            polish.Add("noChangeUntilRestart", "Aby zastosować tą opcję należy zrestartować aplikację");
            french.Add("noChangeUntilRestart", "Cette option ne prendra effet qu'au redémarrage de l'application");
            russian.Add("noChangeUntilRestart", "Для применения настроек потребуется перезапуск программы");
            #endregion

            #region Scaling Verification Window
            //Component: form name
            english.Add("FontSettingsVerify", "Scaling");
            german.Add("FontSettingsVerify", "Skalierung");
            polish.Add("FontSettingsVerify", "Skalowanie");
            french.Add("FontSettingsVerify", "Mise à l'échelle");
            russian.Add("FontSettingsVerify", "Масштабирование");

            //Component: SettingsChangedHeader
            english.Add("SettingsChangedHeader", "Your Scaling Settings have changed. Would you like to keep them?");
            german.Add("SettingsChangedHeader", "Deine Skalierungseinstellungen wurden geändert, willst du sie behalten?");
            polish.Add("SettingsChangedHeader", "Twoje opcje skalowania siê zmieni³y. Czy chcia³byœ je zachowaæ?");
            french.Add("SettingsChangedHeader", "Vos paramètres de mise a l'échelle ont changé. Voulez-vous les garders?");
            russian.Add("SettingsChangedHeader", "Ваши настройки масштабирования были изменены. Хотите сохранить их?");

            //Component: RevertingTimeoutText
            english.Add("RevertingTimeoutText", "Reverting in {0} seconds");
            german.Add("RevertingTimeoutText", "In {0} Sekunden werden sie zurückgesetzt");
            polish.Add("RevertingTimeoutText", "Powrót do poprzednich ustawieñ za {0}s.");
            french.Add("RevertingTimeoutText", "Rétablissement dans {0} secondes");
            russian.Add("RevertingTimeoutText", "Отмена изменений через {0} сек.");

            //Component: NoButton
            english.Add("NoButton", "No");
            german.Add("NoButton", "Nein");
            polish.Add("NoButton", "Nie");
            french.Add("NoButton", "Non");
            russian.Add("NoButton", "Нет");

            //Component: YesButton
            english.Add("YesButton", "Yes");
            german.Add("YesButton", "Ja");
            polish.Add("YesButton", "Tak");
            french.Add("YesButton", "Oui");
            russian.Add("YesButton", "Yes");
            #endregion
        }
    }
}