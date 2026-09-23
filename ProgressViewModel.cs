//  -*-  coding: utf-8-with-signature-unix     -*-  //
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

using   System.ComponentModel;
using   System.Runtime.CompilerServices;
using   System.Windows.Input;

using   WpfHelper.Commands;
using   WpfHelper.ViewModels;


namespace  WpfControl.Utils  {

//========================================================================
//
//    ProgressViewModel  class.
//
//    このクラスは別リポジトリ  WpfHelper にある
//    抽象クラス ViewModels.ViewModelBase を利用します
//

public  class  ProgressViewModel<TResult, TProgVal>
        : ViewModelBase, IProgressViewModel
    where TResult  : struct
    where TProgVal : struct
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
    this.m_progress = new Progress<TProgVal>(UpdateProgress);
    this.m_trgModel = model;

    this.ModelTaskCommand   = new SimpleCommand<int>(
            param => RunModelTask(param), _ => ! IsRunning );
    this.PauseCommand   = new SimpleCommand<int>(
            param => PauseTask(param),  _ => IsPauseEnabled() );
    this.ResumeCommand  = new SimpleCommand<int>(
            param => ResumeTask(param), _ => IsResumeEnabled());
}


//========================================================================
//
//    Public Member Functions.
//

//----------------------------------------------------------------
/**
**
**/
public  async  void
PauseTask(int param)
{
    await  System.Threading.Tasks.Task.Delay(param);

    this.IsPaused = true;
}

public  async  void
ResumeTask(int param)
{
    await  System.Threading.Tasks.Task.Delay(param);

    this.IsPaused = false;
}

//----------------------------------------------------------------
/**
**
**/
public  async  void
RunModelTask(int param)
{
    this.IsRunning = true;
    await  System.Threading.Tasks.Task.Delay(param);

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
    set {
        this.m_isCancelable = value;
        RaisePropertyChanged();
    }
}

//----------------------------------------------------------------
/**
**
**/

public  virtual  bool
IsPausable {
    get { return  this.m_isPausable; }
    set {
        this.m_isPausable = value;
        RaisePropertyChanged();
    }
}

//----------------------------------------------------------------
/**
**
**/

public  virtual  bool
IsPaused {
    get { return  this.m_trgModel.IsPaused; }
    set {
        this.m_trgModel.IsPaused = value;
        RaisePropertyChanged();
    }
}

//----------------------------------------------------------------
/**
**
**/

public  virtual  bool
IsRunning {
    get { return  this.m_isRunning; }
    protected set {
        this.m_isRunning = value;
        RaisePropertyChanged();
    }
}

/**   タスクを実行するコマンドを取得するプロパティ  **/
public  virtual  ICommand  ModelTaskCommand  { get; }

/**   ポーズ用のコマンドを取得するプロパティ        **/
public  virtual  ICommand  PauseCommand  { get; }

/**   リジューム用のコマンドを取得するプロパティ    **/
public  virtual  ICommand  ResumeCommand  { get; }


//========================================================================
//
//    Properties.
//

//----------------------------------------------------------------
/**
**
**/
public  virtual  TProgVal
ProgressValue
{
    get { return  this.m_progressValue; }
    set { this.m_progressValue = value;
          RaisePropertyChanged();
    }
}

//----------------------------------------------------------------
/**
**
**/
public  TResult
ResultValue
{
    get { return  this.m_resultValue; }
    set { this.m_resultValue = value;
          RaisePropertyChanged();
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
IsPauseEnabled()
{
    return ( this.IsPausable && this.IsRunning && (! IsPaused) );
}

//----------------------------------------------------------------
/**
**
**/
protected  virtual  bool
IsResumeEnabled()
{
    return ( this.IsPausable && this.IsRunning && IsPaused );
}

//----------------------------------------------------------------
/**
**
**/

protected  override  void
CheckCommandsCanExecute(
        System.String?  propertyName)
{
    RaiseCanExecuteChanged(this.ModelTaskCommand);
    RaiseCanExecuteChanged(this.PauseCommand);
    RaiseCanExecuteChanged(this.ResumeCommand);
}


//----------------------------------------------------------------
/**
**
**/
protected  virtual  void
UpdateProgress(TProgVal progressValue)
{
    this.ResultValue    = this.m_trgModel.CurrentValue;
    this.ProgressValue  = progressValue;
}


//========================================================================
//
//    Member Variables.
//

private   readonly  IProgress<TProgVal>     m_progress;
private   readonly  IProgressModel<TResult, TProgVal>   m_trgModel;

private   TProgVal  m_progressValue = default(TProgVal);
private   TResult   m_resultValue;

private   bool      m_isCancelable  = false;
private   bool      m_isPausable    = true;
private   bool      m_isRunning     = false;


}   //  End of class  ProgressViewModel

}   //  End of namespace  WpfControl.Utils
