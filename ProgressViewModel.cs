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
        this.m_pauseCommand   = new SimpleCommand(
                _ => pauseTask(),  _ => isPauseEnabled() );
        this.m_resumeCommand  = new SimpleCommand(
                _ => resumeTask(), _ => isResumeEnabled());
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
        this.IsPaused = true;
    }

    public  void  resumeTask()
    {
        this.IsPaused = false;
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    public  async  void  runModelTask()
    {
        this.IsRunning = true;
        Task<TResult>  task = Task.Run<TResult>(
            () => this.m_trgModel.runTask(this.m_progress));
        TResult  result = await task;
        this.IsRunning = false;
        this.ResultValue = result;
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
    IsPaused {
        get { return  this.m_trgModel.IsPaused; }
        set { this.m_trgModel.IsPaused = value;
              raisePropertyChanged();
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
              raisePropertyChanged();
        }
    }

    //----------------------------------------------------------------
    /**   タスクを実行するコマンドを取得するプロパティ
    **
    **/
    public  virtual  ICommand
    ModelTaskCommand {
        get { return  this.m_runTaskCommand; }
    }

    //----------------------------------------------------------------
    /**   ポーズ用のコマンドを取得するプロパティ
    **
    **/
    public  virtual  ICommand
    PauseCommand {
        get { return  this.m_pauseCommand; }
    }

    public  virtual  TProgVal
    ProgressValue
    {
        get { return  this.m_progressValue; }
        set { this.m_progressValue = value;
              raisePropertyChanged(nameof(ProgressValue));
        }
    }

    //----------------------------------------------------------------
    /**   リジューム用のコマンドを取得するプロパティ
    **
    **/
    public  virtual  ICommand
    ResumeCommand {
        get { return  this.m_resumeCommand;
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

    //----------------------------------------------------------------
    /**
    **
    **/
    protected  virtual  bool
    isPauseEnabled()
    {
        return ( this.IsPausable && this.IsRunning && (! IsPaused) );
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    protected  virtual  bool
    isResumeEnabled()
    {
        return ( this.IsPausable && this.IsRunning && IsPaused );
    }

    protected  virtual  void
    updateProgress(TProgVal progressValue)
    {
        this.ResultValue    = this.m_trgModel.CurrentValue;
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
    private  readonly   SimpleCommand   m_resumeCommand;

    private  TProgVal   m_progressValue = default(TProgVal);
    private  TResult    m_resultValue;

    private  bool   m_isCancelable  = false;
    private  bool   m_isPausable    = true;
    private  bool   m_isRunning     = false;
    private  bool   m_isPaused      = false;

}   //  End class ProgressViewModel

}   //  End of namespace  WpfControl.Utils
