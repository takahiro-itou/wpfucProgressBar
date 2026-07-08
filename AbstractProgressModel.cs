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

public abstract class  AbstractProgressModel
        : IProgressModel
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
    public  virtual  void
    setProgress(IProgress<int>? progress)
    {
        this.m_progress = progress;
    }


//========================================================================
//
//    Protected Member Functions.
//

//========================================================================
//
//    Member Variables.
//

    /**   プログレス。  **/
    protected   IProgress<int>?     m_progress;


}   //  End class AbstractProgressModel

}   //  End of namespace  WpfControl.Utils
