import React, { useState, useEffect } from "react";
import { X, Save, User, FileText, Activity, Check, DollarSign, Trash2, Plus, Calendar, Disc } from "lucide-react"; 
import { orderService } from "../api";

const OrderDetailModal = ({ order, staff, user, onClose, onSave }) => {
  // Statü Helper
  const STATUS_LABELS = {
    0: "Bekliyor",
    1: "İşlemde",
    2: "Tamamlandı",
    3: "İptal"
  };

  const getStatusId = (statusStr) => {
    if (statusStr === undefined || statusStr === null) return 0;
    if (typeof statusStr === "number") return statusStr;
    const s = String(statusStr).toLowerCase();
    if (s.includes("bekliyor") || s.includes("pending")) return 0;
    if (s.includes("işlemde") || s.includes("progress")) return 1;
    if (s.includes("tamam") || s.includes("completed")) return 2;
    if (s.includes("iptal") || s.includes("cancel")) return 3;
    return 0;
  };

  const [personnelIds, setPersonnelIds] = useState(order.personnelIds || []);
  const [statusId, setStatusId] = useState(getStatusId(order.status));
  const [description, setDescription] = useState(order.description || "");
  const [isPaid, setIsPaid] = useState(order.isPaid || false); 
  const [loading, setLoading] = useState(false);

  const [services, setServices] = useState(order.services || []);
  const [newService, setNewService] = useState({ product: "", price: "" });

  const totalPrice = services.reduce((sum, item) => sum + (parseFloat(item.price) || 0), 0);

  const toggleStaff = (id) => {
    setPersonnelIds(prev => 
      prev.includes(id) ? prev.filter(pid => pid !== id) : [...prev, id]
    );
  };

  const handleAddService = () => {
    if (!newService.product) return;
    setServices([...services, { ...newService, price: parseFloat(newService.price) || 0, category: "Ekstra", part: "-" }]);
    setNewService({ product: "", price: "" });
  };

  const handleDeleteService = (index) => {
    setServices(services.filter((_, i) => i !== index));
  };

  const handleUpdateServicePrice = (index, value) => {
      const newServices = [...services];
      newServices[index].price = value;
      setServices(newServices);
  };

  const handleSave = async () => {
    setLoading(true);
    try {
        await onSave({
            ...order,
            personnelIds,
            status: STATUS_LABELS[statusId], 
            description,
            isPaid,
            services,
            totalPrice
        });
        onClose();
    } catch (e) {
        console.error(e);
    } finally {
        setLoading(false);
    }
  };

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/50 backdrop-blur-sm p-4 animate-in fade-in duration-200">
        <div className="bg-white dark:bg-dark-card w-full max-w-4xl max-h-[90vh] rounded-2xl shadow-2xl flex flex-col overflow-hidden">
            {/* HEADER */}
            <div className="flex justify-between items-center p-4 border-b dark:border-dark-border bg-gray-50 dark:bg-dark-hover/20">
                <div className="flex items-center gap-3">
                    <div className="p-2 bg-blue-100 text-blue-600 rounded-lg dark:bg-blue-900/30 dark:text-blue-400">
                        <FileText size={20} />
                    </div>
                    <div>
                        <h2 className="font-bold text-lg text-gray-800 dark:text-gray-100">Sipariş Detayı</h2>
                        <span className="text-xs text-gray-500 dark:text-gray-400">#{order?.id || "---"}</span>
                    </div>
                </div>
                <button onClick={onClose} className="p-2 text-gray-400 hover:text-red-500 hover:bg-red-50 rounded-full transition-colors dark:hover:bg-red-900/20">
                    <X size={20} />
                </button>
            </div>

            {/* BODY */}
            <div className="p-4 overflow-y-auto space-y-4 flex-1">
            {/* DURUM & ÖDEME KARTI */}
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div className="space-y-2">
                    <label className="text-xs font-bold uppercase text-gray-400">İşlem Durumu</label>
                    <div className="grid grid-cols-2 gap-2">
                        {[
                            { id: 0, label: "Bekliyor", color: "text-orange-800 bg-orange-100 border-orange-200 dark:bg-orange-900/30 dark:text-orange-300 dark:border-orange-800" },
                            { id: 1, label: "İşlemde", color: "text-blue-800 bg-blue-100 border-blue-200 dark:bg-blue-900/30 dark:text-blue-300 dark:border-blue-800" },
                            { id: 2, label: "Tamamlandı", color: "text-green-800 bg-green-100 border-green-200 dark:bg-green-900/30 dark:text-green-300 dark:border-green-800" },
                            { id: 3, label: "İptal", color: "text-red-800 bg-red-100 border-red-200 dark:bg-red-900/30 dark:text-red-300 dark:border-red-800" }
                        ].map(s => (
                            <button key={s.id} onClick={() => setStatusId(s.id)}
                            className={`px-3 py-2 rounded-lg border text-sm font-medium transition-all flex items-center justify-center gap-2
                                ${statusId === s.id ? `${s.color} ring-2 ring-offset-1 ring-gray-200 dark:ring-dark-border font-bold` : "border-gray-200 text-gray-500 hover:bg-gray-50 dark:border-dark-border dark:text-gray-400 dark:hover:bg-dark-hover"}`}>
                                {s.label}
                                {statusId === s.id && <Check size={14}/>}
                            </button>
                        ))}
                    </div>
                </div>

                <div className="space-y-2">
    {/* ... Payment section ... */}
                    <div onClick={() => setIsPaid(!isPaid)} className={`cursor-pointer border rounded-xl p-3 flex items-center justify-between transition-all
                        ${isPaid ? "bg-green-50 border-green-200 dark:bg-green-900/10 dark:border-green-800" : "bg-gray-50 border-gray-200 dark:bg-dark-card dark:border-dark-border hover:bg-gray-100"}`}>
                        <div className="flex items-center gap-3">
                            <div className={`p-2 rounded-full ${isPaid ? "bg-green-200 text-green-700 dark:bg-green-800 dark:text-green-200" : "bg-gray-200 text-gray-500 dark:bg-dark-hover"}`}>
                                <DollarSign size={20}/>
                            </div>
                            <div>
                                <p className={`font-bold text-sm ${isPaid ? "text-green-800 dark:text-green-300" : "text-gray-700 dark:text-gray-300"}`}>{isPaid ? "Ödeme Alındı" : "Ödeme Bekliyor"}</p>
                                <p className="text-xs text-gray-500 dark:text-gray-400">{isPaid ? "Tahsilat Tamamlandı" : "Henüz işlem yapılmadı"}</p>
                            </div>
                        </div>
                        {isPaid && <Check size={20} className="text-green-600"/>}
                    </div>
                </div>
            </div>

            {/* PERSONEL SEÇİMİ (unchanged) */}
            <div className="space-y-2">
                <label className="text-xs font-bold uppercase text-gray-400 flex items-center gap-2"><User size={14}/> Personel Ata</label>
                <div className="flex flex-wrap gap-2">
                    {staff.map(p => {
                        const isSelected = personnelIds.includes(p.id);
                        return (
                            <button key={p.id} onClick={() => toggleStaff(p.id)}
                            className={`px-3 py-1.5 rounded-full text-sm border transition-colors flex items-center gap-2
                            ${isSelected 
                                ? "bg-purple-100 border-purple-300 text-purple-800 dark:bg-purple-900/30 dark:border-purple-800 dark:text-purple-300" 
                                : "bg-white border-gray-200 text-gray-600 hover:border-gray-300 dark:bg-dark-bg dark:border-dark-border dark:text-gray-400"}`}>
                                <div className="flex flex-col items-start leading-tight">
                                    <span className="font-bold">{p.fullName || p.FullName}</span>
                                    <span className="text-[10px] opacity-75">{p.position || p.Position || "Personel"}</span>
                                </div>
                                {isSelected && <Check size={14}/>}
                            </button>
                        );
                    })}
                    {staff.length === 0 && <span className="text-xs text-gray-400 italic">Personel listesi boş.</span>}
                </div>
            </div>

            {/* HİZMETLER TABLOSU */}
            <div className="space-y-2">
                <div className="flex justify-between items-end">
                    <label className="text-xs font-bold uppercase text-gray-400 flex items-center gap-2"><Activity size={14}/> Yapılan İşlemler</label>
                    <span className="text-sm font-medium text-gray-500 dark:text-gray-400">{services.length} Kalem</span>
                </div>
                
                <div className="border rounded-lg overflow-hidden bg-white dark:bg-dark-bg/20 dark:border-dark-border">
                    <table className="w-full text-sm text-left">
                        <thead className="bg-gray-50 text-gray-500 dark:bg-dark-hover dark:text-gray-400 border-b dark:border-dark-border">
                            <tr>
                                <th className="p-3 font-medium">Hizmet / Ürün</th>
                                <th className="p-3 font-medium">Parça</th>
                                <th className="p-3 font-medium w-32">Fiyat (₺)</th>
                                <th className="p-3 w-10"></th>
                            </tr>
                        </thead>
                        <tbody className="divide-y dark:divide-dark-border">
                            {services.map((svc, idx) => (
                                <tr key={idx} className="group hover:bg-gray-50 dark:hover:bg-dark-hover/50">
                                    <td className="p-3 font-medium text-gray-800 dark:text-gray-200">
                                        <div className="flex flex-col">
                                            <span className="text-xs text-gray-400 dark:text-gray-500">{svc.category}</span>
                                            <span>{svc.product}</span>
                                        </div>
                                    </td>
                                    <td className="p-3 text-gray-500 dark:text-gray-400 text-xs">{svc.part}</td>
                                    <td className="p-3">
                                        {user?.role === "Admin" ? (
                                            <input 
                                                type="number" 
                                                className="w-full bg-transparent border-b border-transparent focus:border-blue-500 outline-none text-right font-mono"
                                                value={svc.price}
                                                onChange={(e) => handleUpdateServicePrice(idx, e.target.value)}
                                            />
                                        ) : (
                                            <button onClick={() => {
                                                const newPrice = prompt(`"${svc.product}" için yeni fiyatı giriniz:`, svc.price);
                                                if (newPrice && newPrice !== svc.price) {
                                                    const note = prompt("Fiyat değişikliği için açıklama (opsiyonel):");
                                                    orderService.requestPriceChange(order.id, { serviceName: svc.product, oldPrice: svc.price, newPrice, note })
                                                        .then(() => alert("Fiyat değişim talebi iletildi."))
                                                        .catch(e => alert("Hata: " + e.message));
                                                }
                                            }} className="w-full text-right font-mono hover:text-blue-600 underline decoration-dashed underline-offset-4 cursor-pointer">
                                                {svc.price}
                                            </button>
                                        )}
                                    </td>
                                    <td className="p-3 text-right">
                                        {user?.role === "Admin" ? (
                                            <button onClick={() => handleDeleteService(idx)} className="text-gray-400 hover:text-red-500 transition-colors opacity-0 group-hover:opacity-100">
                                                <Trash2 size={16}/>
                                            </button>
                                        ) : (
                                            <button onClick={() => {
                                                const note = prompt(`"${svc.product}" silinecek. Açıklama giriniz:`);
                                                if (note !== null) {
                                                    orderService.requestServiceDelete(order.id, { serviceName: svc.product, note })
                                                        .then(() => alert("Silme talebi iletildi."))
                                                        .catch(e => alert("Hata: " + e.message));
                                                }
                                            }} className="text-gray-400 hover:text-orange-500 transition-colors opacity-0 group-hover:opacity-100" title="Silme Talebi Oluştur">
                                                <AlertTriangle size={16}/>
                                            </button>
                                        )}
                                    </td>
                                </tr>
                            ))}
                            {services.length === 0 && (
                                <tr><td colSpan="4" className="p-6 text-center text-gray-400 italic border-dashed">Henüz işlem eklenmemiş.</td></tr>
                            )}
                        </tbody>
                        <tfoot className="bg-gray-50 dark:bg-dark-hover/30 font-bold border-t dark:border-dark-border">
                            <tr>
                                <td colSpan="2" className="p-3 text-right text-gray-600 dark:text-gray-300">TOPLAM:</td>
                                <td className="p-3 text-right text-blue-600 dark:text-brand text-lg">₺{totalPrice.toLocaleString()}</td>
                                <td></td>
                            </tr>
                        </tfoot>
                    </table>
                    
                    {/* HIZLI EKLEME ALANI - Staff da ekleyebilir, sadece silemez/düzenleyemez */}
                    <div className="p-2 bg-gray-50 dark:bg-dark-hover/50 border-t dark:border-dark-border flex gap-2">
                        <input 
                            placeholder="Yeni işlem adı..." 
                            className="flex-1 px-3 py-2 rounded border border-gray-200 dark:border-dark-border dark:bg-dark-card dark:text-white text-sm focus:ring-1 focus:ring-blue-500 outline-none"
                            value={newService.product} 
                            onChange={e=>setNewService({...newService, product:e.target.value})} 
                            onKeyDown={e => e.key === 'Enter' && handleAddService()}
                        />
                        <input 
                            type="number" 
                            placeholder="Fiyat" 
                            className="w-24 px-3 py-2 rounded border border-gray-200 dark:border-dark-border dark:bg-dark-card dark:text-white text-sm focus:ring-1 focus:ring-blue-500 outline-none"
                            value={newService.price} 
                            onChange={e=>setNewService({...newService, price:e.target.value})} 
                            onKeyDown={e => e.key === 'Enter' && handleAddService()}
                        />
                        <button onClick={handleAddService} className="bg-blue-600 hover:bg-blue-700 text-white px-3 rounded flex items-center justify-center">
                            <Plus size={18}/>
                        </button>
                    </div>
                </div>
            </div>

            {/* AÇIKLAMA */}
            <div className="space-y-2">
                <label className="text-xs font-bold uppercase text-gray-400 flex items-center gap-2"><FileText size={14}/> Notlar</label>
                <textarea 
                    className="w-full border rounded-lg p-3 text-sm min-h-[80px] outline-none focus:ring-2 focus:ring-blue-500 transition-all
                    border-gray-200 bg-white text-gray-800 dark:border-dark-border dark:bg-dark-card dark:text-gray-200"
                    placeholder="İş emri ile ilgili notlar..."
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                />
            </div>

        </div>

        {/* FOOTER */}
        <div className="p-4 border-t bg-gray-50 dark:bg-dark-card flex justify-between items-center dark:border-dark-border">
            <span className="text-xs text-gray-400">Değişiklikleri kaydetmeyi unutmayın.</span>
            <div className="flex gap-3">
                <button onClick={onClose} className="px-5 py-2.5 rounded-lg text-sm font-medium text-gray-600 hover:bg-gray-200 dark:text-gray-400 dark:hover:bg-dark-hover transition-colors">İptal</button>
                <button onClick={handleSave} disabled={loading} className="px-6 py-2.5 rounded-lg text-sm font-bold text-white bg-blue-600 hover:bg-blue-700 shadow-md shadow-blue-200 dark:shadow-none dark:bg-brand dark:hover:bg-brand-dark flex items-center gap-2 transition-all active:scale-95 disabled:opacity-70 disabled:active:scale-100">
                    {loading ? <div className="w-5 h-5 border-2 border-white/30 border-t-white rounded-full animate-spin"/> : <Save size={18}/>}
                    <span>Kaydet</span>
                </button>
            </div>
        </div>

      </div>
    </div>
  );
};

export default OrderDetailModal;
