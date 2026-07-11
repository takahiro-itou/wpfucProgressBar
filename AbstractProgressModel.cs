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
//    AbstractProgressViewModel  class.
//

public abstract class  AbstractProgressModel<TResult, TProgVal>
        : IProgressModel<TResult, TProgVal>
    where TResult  : System.Numerics.INumber<TResult>
    where TProgVal : System.Numerics.INumber<TProgVal>
{

    //----------------------------------------------------------------
    /**   コンストラクタ。
    **
    **/
    public
    AbstractProgressModel()
    {
    }


//========================================================================
//
//    Public Member Functions.
//

    //----------------------------------------------------------------
    /**
    **
    **/
    public  virtual  TResult
    runTask(
        IProgress<TProgVal> progress)
    {
        int total = 0;

        progress.Report(1);
        for ( int i = 1; i <= 20; ++ i ) {
            total += i;
            Thread.Sleep(100);
            progress.Report(i * 5);
        }

        return ( (TResult)total );
    }


//========================================================================
//
//    Properties.
//


//========================================================================
//
//    Accessors.
//

//========================================================================
//
//    Protected Member Functions.
//

//========================================================================
//
//    Member Variables.
//

}   //  End class AbstractProgressModel

}   //  End of namespace  WpfControl.Utils
