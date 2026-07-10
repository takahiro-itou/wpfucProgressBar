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


namespace  WpfControl.Utils  {

//========================================================================
//
//    IProgressModel  interface.
//

public  interface  IProgressModel
{

//========================================================================
//
//    Public Member Functions.
//

    //----------------------------------------------------------------
    /**
    **
    **/
    public  int;
    runTask();


//========================================================================
//
//    Properties.
//

//========================================================================
//
//    Accessors.
//

    //----------------------------------------------------------------
    /**   プログレスインスタンスを指定する。
    **
    **  @param [in] progress
    **/
    public  void
    setProgress(IProgress<int>  progress);


}   //  End interface IProgressModel

}   //  End of namespace  WpfControl.Utils
