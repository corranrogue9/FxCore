namespace System
{
    /// <summary>
    /// Encapsulates a method that has no input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<TOut, out TResult>(out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has one input parameter, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn">The type of the input parameter of the method that this delegate encapsulates</typeparam>  
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg">The input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn, TOut, out TResult>(TIn inArg, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has two input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has three input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has four input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has five input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has six input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has seven input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has eight input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn8">The type of the eighth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg8">The eighth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, in TIn8, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, TIn8 inArg8, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has nine input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn8">The type of the eighth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn9">The type of the ninth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg8">The eighth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg9">The ninth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, in TIn8, in TIn9, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, TIn8 inArg8, TIn9 inArg9, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has ten input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn8">The type of the eighth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn9">The type of the ninth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn10">The type of the tenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg8">The eighth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg9">The ninth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg10">The tenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, in TIn8, in TIn9, in TIn10, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, TIn8 inArg8, TIn9 inArg9, TIn10 inArg10, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has eleven input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn8">The type of the eighth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn9">The type of the ninth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn10">The type of the tenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn11">The type of the eleventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg8">The eighth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg9">The ninth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg10">The tenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg11">The eleventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, in TIn8, in TIn9, in TIn10, in TIn11, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, TIn8 inArg8, TIn9 inArg9, TIn10 inArg10, TIn11 inArg11, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has twelve input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn8">The type of the eighth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn9">The type of the ninth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn10">The type of the tenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn11">The type of the eleventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn12">The type of the twelfth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg8">The eighth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg9">The ninth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg10">The tenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg11">The eleventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg12">The twelfth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, in TIn8, in TIn9, in TIn10, in TIn11, in TIn12, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, TIn8 inArg8, TIn9 inArg9, TIn10 inArg10, TIn11 inArg11, TIn12 inArg12, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has thirteen input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn8">The type of the eighth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn9">The type of the ninth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn10">The type of the tenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn11">The type of the eleventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn12">The type of the twelfth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn13">The type of the thirteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg8">The eighth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg9">The ninth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg10">The tenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg11">The eleventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg12">The twelfth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg13">The thirteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, in TIn8, in TIn9, in TIn10, in TIn11, in TIn12, in TIn13, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, TIn8 inArg8, TIn9 inArg9, TIn10 inArg10, TIn11 inArg11, TIn12 inArg12, TIn13 inArg13, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has fourteen input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn8">The type of the eighth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn9">The type of the ninth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn10">The type of the tenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn11">The type of the eleventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn12">The type of the twelfth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn13">The type of the thirteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn14">The type of the fourteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg8">The eighth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg9">The ninth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg10">The tenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg11">The eleventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg12">The twelfth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg13">The thirteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg14">The fourteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, in TIn8, in TIn9, in TIn10, in TIn11, in TIn12, in TIn13, in TIn14, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, TIn8 inArg8, TIn9 inArg9, TIn10 inArg10, TIn11 inArg11, TIn12 inArg12, TIn13 inArg13, TIn14 inArg14, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has fifteen input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn8">The type of the eighth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn9">The type of the ninth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn10">The type of the tenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn11">The type of the eleventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn12">The type of the twelfth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn13">The type of the thirteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn14">The type of the fourteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn15">The type of the fifteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg8">The eighth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg9">The ninth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg10">The tenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg11">The eleventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg12">The twelfth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg13">The thirteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg14">The fourteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg15">The fifteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, in TIn8, in TIn9, in TIn10, in TIn11, in TIn12, in TIn13, in TIn14, in TIn15, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, TIn8 inArg8, TIn9 inArg9, TIn10 inArg10, TIn11 inArg11, TIn12 inArg12, TIn13 inArg13, TIn14 inArg14, TIn15 inArg15, out TOut outArg);

    /// <summary>
    /// Encapsulates a method that has sixteen input parameters, one output parameter, and returns a value of the type specified by the <typeparamref name="TResult"/> parameter
    /// </summary>
    /// <typeparam name="TIn1">The type of the first input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn2">The type of the second input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn3">The type of the third input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn4">The type of the fourth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn5">The type of the fifth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn6">The type of the sixth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn7">The type of the seventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn8">The type of the eighth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn9">The type of the ninth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn10">The type of the tenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn11">The type of the eleventh input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn12">The type of the twelfth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn13">The type of the thirteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn14">The type of the fourteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn15">The type of the fifteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TIn16">The type of the sixteenth input parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TOut">The type of the output parameter of the method that this delegate encapsulates</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <param name="inArg1">The first input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg2">The second input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg3">The third input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg4">The fourth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg5">The fifth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg6">The sixth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg7">The seventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg8">The eighth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg9">The ninth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg10">The tenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg11">The eleventh input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg12">The twelfth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg13">The thirteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg14">The fourteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg15">The fifteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="inArg16">The sixteenth input parameter of the method that this delegate encapsulates</param>
    /// <param name="outArg">The output parameter of the method that this delegate encapsulates</param>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    public delegate TResult OutFunc<in TIn1, in TIn2, in TIn3, in TIn4, in TIn5, in TIn6, in TIn7, in TIn8, in TIn9, in TIn10, in TIn11, in TIn12, in TIn13, in TIn14, in TIn15, in TIn16, TOut, out TResult>(TIn1 inArg1, TIn2 inArg2, TIn3 inArg3, TIn4 inArg4, TIn5 inArg5, TIn6 inArg6, TIn7 inArg7, TIn8 inArg8, TIn9 inArg9, TIn10 inArg10, TIn11 inArg11, TIn12 inArg12, TIn13 inArg13, TIn14 inArg14, TIn15 inArg15, TIn16 inArg16, out TOut outArg);
}
