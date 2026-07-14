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
    where TResult : struct
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
    public  abstract  TResult
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
    CurrentValue {
        get { return  this.m_curValue; }
        set { this.m_curValue = value; }
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  bool
    IsPaused {
        get { return  this.m_isPaused; }
        set { this.m_isPaused = value; }
    }


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

    private  TResult    m_curValue;

    private  bool       m_isPaused;

}   //  End class AbstractProgressModel

}   //  End of namespace  WpfControl.Utils
