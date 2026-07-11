//  -*-  coding: utf-8-with-signature-unix;        -*-  //
/*************************************************************************
**                                                                      **
**                  ---  WPF UserControl Library.  ---                  **
**                                                                      **
**          Copyright (C), 2026-2026, Takahiro Itou                     **
**          All Rights Reserved.                                        **
**                                                                      **
**          License: (See COPYING or LICENSE files)                     **
**          GNU Affero General Public License (AGPL) version 3,         **
**          or (at your option) any later version.                      **
**                                                                      **
*************************************************************************/

using System.Windows.Input;


namespace  WpfControl.Utils  {

//========================================================================
//
//    IProgressViewModel  interface.
//

public  interface  IProgressViewModel
{

    //----------------------------------------------------------------
    /**
    **
    **/
    public  bool
    IsCancelable { get; set; }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  bool
    IsPausable { get; set; }

    //----------------------------------------------------------------
    /**   タスクを実行するコマンドを取得するプロパティ
    **
    **/
    public  ICommand
    ModelTaskCommand { get; }

    //----------------------------------------------------------------
    /**   ポーズ用のコマンドを取得するプロパティ
    **
    **/
    public  ICommand
    PauseCommand { get; }

    public  TProgVal
    ProgressValue { get; set; }

    //----------------------------------------------------------------
    /**   リジューム用のコマンドを取得するプロパティ
    **
    **/
    public  ICommand
    ResumeCommand { get; }


}   //  End interface IProgressViewModel

}   //  End of namespace  WpfControl.Utils
