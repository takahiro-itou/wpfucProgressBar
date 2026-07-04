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

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using WpfControl.Common;


namespace  WpfControl.Utils  {

//========================================================================
//
//    ProgressViewModel  class.
//
//    このクラスは別リポジトリ WpfControlLibrary  にある
//    Common.SimpleCommand  を利用します
//

public class  ProgressViewModel
        : INotifyPropertyChanged, IProgressViewModel
{

//========================================================================
//
//    Constructor(s) and Destructor.
//

    //----------------------------------------------------------------
    /**   コンストラクタ。
    **
    **/
    public
    ProgressViewModel()
    {
    }


//========================================================================
//
//    Public Properties (Implement Interface).
//

//========================================================================
//
//    Protected Member Functions (Pure Virtual Functions).
//

//========================================================================
//
//    Protected Member Functions.
//

//========================================================================
//
//    Member Variables.
//

}   //  End class ProgressViewModel

}   //  End of namespace  WpfControl.Utils
