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

public class  ProgressViewModel<TResult, TProgVal>
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
    ProgressViewModel(
            IProgressModel<TResult, TProgVal>   model)
    {
        this.m_progress = new Progress<TProgVal>(updateProgress);
        this.m_trgModel = model;

        this.m_runTaskCommand = new SimpleCommand(_ => runModelTask());
        this.m_pauseCommand   = new SimpleCommand(_ => pauseTask());
    }


//========================================================================
//
//    Public Member Functions.
//

    //----------------------------------------------------------------
    /**
    **
    **/
    public  void  pauseTask()
    {
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  async  void  runModelTask()
    {
        //Task<int> task = Task.Run<int>(new Func<int>(
        //    m_trgModel.runTask));
        Task<TResult>  task = Task.Run<int>(
            () => this.m_trgModel.runTask(this.m_progress));
        TResult  result = await task;
    }


//========================================================================
//
//    Public Properties (Implement Interface).
//

    //----------------------------------------------------------------
    /**
    **
    **/
    public  virtual  bool
    IsCancelable {
        get { return  this.m_isCancelable; }
        set { this.m_isCancelable = value;
              raisePropertyChanged(nameof(IsCancelable));
       }
    }


    //----------------------------------------------------------------
    /**
    **
    **/
    public  virtual  bool
    IsPausable {
        get { return  this.m_isPausable; }
        set { this.m_isPausable = value;
              raisePropertyChanged(nameof(IsPausable));
        }
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  virtual  bool
    IsPauseEnabled {
        get {
            return ( this.m_isPausable && this.m_isRunning
                && (! this.m_isPaused)
            );
        }
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  virtual  bool
    IsResumeEnabled {
        get {
            return ( this.m_isPausable && ! this.m_isRunning
                && this.m_isPaused
            );
        }
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  virtual  bool
    IsPaused {
        get { return  this.m_isPaused; }
        set { this.m_isPaused = value;
              raisePropertyChanged(nameof(IsPaused));
       }
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  virtual  bool
    IsRunning {
        get { return  this.m_isRunning; }
        set { this.m_isRunning = value;
              raisePropertyChanged(nameof(IsRunning));
        }
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  event PropertyChangedEventHandler?  PropertyChanged;


//========================================================================
//
//    Properties.
//

    public  ICommand    ModelTaskCommand => m_runTaskCommand;
    public  ICommand    PauseCommand     => m_pauseCommand;

    public  TProgVal
    ProgressValue
    {
        get { return  this.m_progressValue; }
        set { this.m_progressValue = value;
              raisePropertyChanged(nameof(ProgressValue));
        }
    }

    public  TResult
    ResultValue
    {
        get { return  this.m_resultValue; }
        set { this.m_resultValue = value;
              raisePropertyChanged(nameof(ResultValue));
        }
    }


//========================================================================
//
//    Protected Member Functions (Pure Virtual Functions).
//

//========================================================================
//
//    Protected Member Functions.
//

    protected  virtual  void
    updateProgress(TProgVal progressValue)
    {
        this.ProgressValue  = progressValue;
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    protected  virtual  void
    raisePropertyChanged(
            [CallerMemberName]  System.String?  propertyName = null)
    {
        PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName));
    }

//========================================================================
//
//    Member Variables.
//

    private  readonly   IProgress<TProgVal>     m_progress;
    private  readonly   IProgressModel<TResult, TProgVal>   m_trgModel;

    private  readonly   SimpleCommand   m_runTaskCommand;
    private  readonly   SimpleCommand   m_pauseCommand;

    private  int    m_progressValue = 0;
    private  int    m_resultValue   = 0;

    private  bool   m_isCancelable  = true;
    private  bool   m_isPausable    = true;
    private  bool   m_isRunning     = false;
    private  bool   m_isPaused      = false;

}   //  End class ProgressViewModel

}   //  End of namespace  WpfControl.Utils
