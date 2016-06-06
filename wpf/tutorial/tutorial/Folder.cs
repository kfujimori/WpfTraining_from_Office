using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace tutorial
{
    public class Folder
    {
        //フィールド
        private DirectoryInfo _folder;
        private ObservableCollection<Folder> _subFolders;
        private ObservableCollection<FileInfo> _files;

        //コンストラクタ
        public Folder()
        {
            this.FullPath = @"c:\";
        }

        //フォルダ名の取得
        public string Name
        {
            get
            {
                return this._folder.Name;
            }
        }

        //ディレクトリ情報の取得・登録
        public string FullPath
        {
            get
            {
                return this._folder.FullName;
            }
            set
            {
                if (Directory.Exists(value))
                {
                    this._folder = new DirectoryInfo(value);
                }
                else
                {
                    throw new ArgumentException("must exist", "fullPath");
                }
            }
        }

        //フォルダ配下のファイルを全件取得
        public ObservableCollection<FileInfo> Files
        {
            get
            {
                if (this._files == null)
                {
                    this._files = new ObservableCollection<FileInfo>();

                    try
                    {
                        FileInfo[] fi = this._folder.GetFiles();
                        for (int i = 0; i < fi.Length; i++)
                        {
                            this._files.Add(fi[i]);
                        }
                    }
                    catch (UnauthorizedAccessException UAEx)
                    {
                        throw new UnauthorizedAccessException(UAEx.Message);
                    }                
                }
                return this._files;
            }
        }

        //フォルダ配下のサブフォルダを全件取得
        public ObservableCollection<Folder> SubFolders
        {
            get
            {
                if (this._subFolders == null)
                {
                    this._subFolders = new ObservableCollection<Folder>();
                    DirectoryInfo[] di;
                    try
                    {
                        di = this._folder.GetDirectories();
                        for (int i = 0; i < di.Length; i++)
                        {
                            Folder newFolder = new Folder();
                            newFolder.FullPath = di[i].FullName;
                            this._subFolders.Add(newFolder);
                        }
                    }
                    catch (UnauthorizedAccessException UAEx)
                    {
                        throw new UnauthorizedAccessException(UAEx.Message);
                    }

                }
                return this._subFolders;
            }
        }
    }
}
