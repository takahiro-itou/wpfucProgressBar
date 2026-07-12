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

public  interface  IProgressModel<TResult, TProgVal>
{

//========================================================================
//
//    Public Member Functions.
//

    //----------------------------------------------------------------
    /**
    **
    **/
    public  TResult
    runTask(
        IProgress<TProgVal> progress);


//========================================================================
//
//    Properties.
//

    //----------------------------------------------------------------
    /**
    **
    **/
    public  TResult
    CurrentValue { get; set; }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  bool
    IsPaused { get; set; }


//========================================================================
//
//    Accessors.
//


}   //  End interface IProgressModel

}   //  End of namespace  WpfControl.Utils
