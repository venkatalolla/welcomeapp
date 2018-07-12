#/bin/bash

export CLUSTER_ENDPOINT=`aws eks describe-cluster --name dotnet-webinar --query cluster.endpoint`
export CLUSTER_CERT=`aws eks describe-cluster --name dotnet-webinar --query cluster.certificateAuthority.data`
# replace lines in $KUBECONFIG
eval `aws ecr get-login --no-include-email`
echo `aws ecr get-login --no-include-email` > $PROJECT_DIR/ecr-login.sh


kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/master/src/deploy/recommended/kubernetes-dashboard.yaml
kubectl apply -f https://raw.githubusercontent.com/kubernetes/heapster/master/deploy/kube-config/influxdb/heapster.yaml
kubectl apply -f https://raw.githubusercontent.com/kubernetes/heapster/master/deploy/kube-config/influxdb/influxdb.yaml
kubectl apply -f https://raw.githubusercontent.com/kubernetes/heapster/master/deploy/kube-config/rbac/heapster-rbac.yaml
kubectl apply -f $PROJECT_DIR/kube/eks-admin-service-account.yml
kubectl apply -f $PROJECT_DIR/kube/eks-admin-cluster-role-binding.yml
kubectl -n kube-system describe secret $(kubectl -n kube-system get secret | grep eks-admin | awk '{print $1}') > kube-creds.txt

kubectl proxy &

export KUBE_PROXY_PID=`ps -a | grep "kubectl proxy" | grep -v grep | awk '{ print $1 }'`

echo "http://localhost:8001/api/v1/namespaces/kube-system/services/https:kubernetes-dashboard:/proxy/"
