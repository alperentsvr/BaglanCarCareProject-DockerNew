import React from 'react';
import { AlertTriangle, RefreshCcw } from 'lucide-react';

class ErrorBoundary extends React.Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false, error: null, errorInfo: null };
  }

  static getDerivedStateFromError(error) {
    // Bir sonraki render'da fallback UI göstermek için state güncelle
    return { hasError: true, error };
  }

  componentDidCatch(error, errorInfo) {
    // Hatayı loglama servisine (örn: Sentry) burada gönderebilirsiniz
    console.error("Uncaught error:", error, errorInfo);
    this.setState({ error, errorInfo });
  }

  handleReload = () => {
    window.location.reload();
  };

  render() {
    if (this.state.hasError) {
      return (
        <div className="min-h-screen flex items-center justify-center bg-gray-100 dark:bg-gray-900 p-4">
          <div className="bg-white dark:bg-gray-800 p-8 rounded-2xl shadow-xl max-w-md w-full text-center border border-gray-200 dark:border-gray-700">
            <div className="w-16 h-16 bg-red-100 dark:bg-red-900/30 rounded-full flex items-center justify-center mx-auto mb-4 text-red-600 dark:text-red-400">
              <AlertTriangle size={32} />
            </div>
            <h2 className="text-2xl font-bold text-gray-800 dark:text-gray-100 mb-2">
              Beklenmedik Bir Hata
            </h2>
            <p className="text-gray-600 dark:text-gray-400 mb-6">
              Üzgünüz, bir şeyler yanlış gitti. Bu durum otomatik olarak raporlandı.
            </p>
            
            <div className="text-left bg-gray-50 dark:bg-gray-900 p-3 rounded mb-6 text-xs font-mono overflow-auto max-h-32 border border-gray-200 dark:border-gray-700">
               {this.state.error && this.state.error.toString()}
            </div>

            <button
              onClick={this.handleReload}
              className="w-full bg-blue-600 hover:bg-blue-700 text-white font-bold py-3 px-4 rounded-xl flex items-center justify-center gap-2 transition-all active:scale-95"
            >
              <RefreshCcw size={18} />
              Sayfayı Yenile
            </button>
          </div>
        </div>
      );
    }

    return this.props.children; 
  }
}

export default ErrorBoundary;
